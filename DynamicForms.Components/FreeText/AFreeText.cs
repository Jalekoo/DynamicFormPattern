using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForms.Engine;

namespace DynamicForms.Components.FreeText
{
    public class AFreeText : ABase
    {
        public AFreeText( QBase question )
            : base( question )
        {
        }

        public string FreeText { get; set; }
    }
}
