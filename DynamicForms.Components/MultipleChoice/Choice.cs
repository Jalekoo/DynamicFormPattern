using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Components
{
    [Serializable]
    public class Choice
    {
        private int _index;
        private QMultipleChoice _parent;

        public string Name { get; set; }

        public string Value { get; set; }

        public QMultipleChoice Parent { get; set; }

        public int Index
        {
            get
            {
                return _index;
            }
            internal set
            {
                _parent.OnChoiceIndexChange( this, value );
            }
        }

        internal void SetIndex( int newIndex )
        {
            _index = newIndex;
        }
    }
}
