using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForms.Engine;

namespace DynamicForms.Components
{
    [Serializable]
    public class QFreeText : QBase
    {
        public QFreeText( Form form, string title, bool isRequired, QBase parent )
            : base( form, title, parent )
        {
        }

        public string FreeAnswer { get; set; }

        public bool AllowEmptyAnswer { get; set; }

        public override ABase CreateAnswer( Form form )
        {
            return (ABase)Activator.CreateInstance( typeof( AFreeText ), this );
        }
    }
}
