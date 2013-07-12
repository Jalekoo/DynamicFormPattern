using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Engine
{
    public static class FormEngine
    {
        public static Form CreateForm( string name )
        {
            return new Form( name );
        }

        public static void Save( string path, Form form )
        {
            throw new NotImplementedException();
        }

        public static Form Load( string path )
        {
            throw new NotImplementedException();
        }
    }
}
