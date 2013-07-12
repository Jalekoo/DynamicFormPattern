using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForms.Engine;

namespace DynamicForms.Components
{
    public class QComposite : QBase
    {
        public QComposite( Form form, string title, bool isRequired, QBase parent )
            : base( form, title, isRequired, parent )
        {
        }

        public override ABase CreateAnswer( Form form )
        {
            throw new NotSupportedException();
        }
    }
}
