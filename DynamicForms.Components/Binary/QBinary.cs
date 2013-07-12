using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForms.Engine;

namespace DynamicForms.Components
{
    [Serializable]
    public class QBinary : QBase
    {
        public QBinary( Form form, string title, bool isRequired, QBase parent )
            : base( form, title, parent )
        {
        }

        public override ABase CreateAnswer( Form form )
        {
            return (ABase)Activator.CreateInstance( typeof( ABinary ), this );
        }
    }
}
