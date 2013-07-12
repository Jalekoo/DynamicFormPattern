using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Engine
{
    public abstract class QBase
    {
        private QBase _parent;
        readonly private List<QBase> _children;
        private int _index;

        public QBase( Form form, string title, bool isRequired, QBase parent )
        {
            Title = title;
            IsRequired = isRequired;
            Form = form;
            _parent = parent;

            _children = new List<QBase>();
        }

        public bool IsRequired { get; set; }

        public string Title { get; set; }

        public int Index
        {
            get
            {
                return _index;
            }
            set
            {
                _parent.OnChildIndexChange( this, _index, value );
            }
        }

        public QBase Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent.OnChildParentChange( this, value );
            }
        }

        public IReadOnlyList<QBase> Children { get { return _children.AsReadOnly(); } }

        public Form Form { get; internal set; }

        public abstract ABase CreateAnswer( Form form );

        private void SetIndex( int index )
        {
            _index = index;
        }

        private void SetParent( QBase parent )
        {
            _parent = parent;
        }

        private void OnChildIndexChange( QBase question, int oldIndex, int newIndex )
        {
            _children.RemoveAt( oldIndex );
            _children.Insert( newIndex, question );

            this.CacheIndexes();
        }

        private void OnChildParentChange( QBase question, QBase newParent )
        {
            question.SetParent( newParent );
            _children.Remove( question );
            this.CacheIndexes();
            newParent._children.Add( question );
            newParent.CacheIndexes();
        }

        private void CacheIndexes()
        {
            for( int i = 0; i < _children.Count; i++ )
                _children[i].SetIndex( i );
        }

        public T AddANewQuestion<T>( string title, bool isRequired ) where T : QBase
        {
            T q = (T)Activator.CreateInstance( typeof( T ), Form, title, isRequired, this );
            _children.Add( q );
            q.SetIndex( _children.Count - 1 );
            return q;
        }

        public bool Contains( QBase question )
        {
            if( question.Parent == null ) return false;
            else if( question.Parent == this ) return true;
            else return Contains( question.Parent );
        }
    }
}
