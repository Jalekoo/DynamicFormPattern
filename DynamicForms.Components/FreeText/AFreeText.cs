using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForms.Engine;

namespace DynamicForms.Components
{
    [Serializable]
    public class AFreeText : ABase
    {
        public AFreeText( QBase question )
            : base( question )
        {
        }

        public string FreeTextAnswer { get; set; }

        public bool AllowEmptyAnswer { get; set; }
    }
}
