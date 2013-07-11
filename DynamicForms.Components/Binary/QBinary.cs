using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForms.Engine;

namespace DynamicForms.Components.Binary
{
    public class QBinary : QBase
    {
        public QBinary( string title, bool isRequired )
            : base( title, isRequired )
        {

        }

        public override Type AnswerType { get { return typeof( ABinary ); } }
    }
}
