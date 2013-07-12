using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForms.Components;
using DynamicForms.Engine;

namespace DynamicForms.Validators
{
    public class RequirementValidator : IValidator
    {
        public void Valid( ABase answer )
        {
            Console.WriteLine( "I'm BASE" );
        }

        public void Valid( AFreeText answer )
        {
            Console.WriteLine( "I'm FreeText" );
        }
    }
}
