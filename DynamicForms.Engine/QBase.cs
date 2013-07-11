using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Engine
{
    public abstract class QBase
    {
        public QBase( string title, bool isRequired )
        {
            Title = title;
            IsRequired = isRequired;
        }

        public string Title { get; set; }

        public bool IsRequired { get; set; }

        public int Index { get; set; }

        public virtual Type AnswerType { get; }
    }
}
