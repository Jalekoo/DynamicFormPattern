using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Engine
{
    public interface IValidator
    {
        void Valid( ABase answer );
    }
}
