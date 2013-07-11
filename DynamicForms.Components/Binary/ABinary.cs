using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForms.Engine;

namespace DynamicForms.Components.Binary
{
    public class ABinary : ABase
    {
        public ABinary( QBase question )
            : base( question )
        {

        }
        public bool Answer { get; set; }
    }
}
