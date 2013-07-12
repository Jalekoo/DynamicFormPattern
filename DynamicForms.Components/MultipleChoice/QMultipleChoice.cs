using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForms.Engine;

namespace DynamicForms.Components
{
    public class QMultipleChoice : QBase
    {
        readonly List<Choice> _choices;
        public QMultipleChoice( Form form, string title, bool isRequired, QBase parent )
            : base( form, title, parent )
        {
            _choices = new List<Choice>();
        }

        public int Min { get; set; }

        public int Max { get; set; }

        public IReadOnlyList<Choice> Choices { get { return _choices.AsReadOnly(); } }

        public void AddANewChoice( string name, string value )
        {
            Choice c = new Choice { Name = name, Value = value, Parent = this };
            _choices.Add( c );
            c.SetIndex( _choices.Count - 1 );
        }

        public void OnChoiceIndexChange( Choice choice, int newIndex )
        {
            _choices.RemoveAt( choice.Index );
            _choices.Insert( newIndex, choice );

            this.CacheIndexes();
        }

        private void CacheIndexes()
        {
            for( int i = 0; i < _choices.Count; i++ )
                _choices[i].SetIndex( i );
        }

        public override ABase CreateAnswer( Form form )
        {
            throw new NotImplementedException();
        }
    }
}
