using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
            IFormatter formatter = new BinaryFormatter();
            using( FileStream bin = new FileStream( Path.Combine( path, String.Format( "Form-{0}.bin", form.Name ) ), FileMode.Create, FileAccess.Write, FileShare.None ) )
            {
                formatter.Serialize( bin, form );
            }
        }

        public static Form Load( string completePath )
        {
            IFormatter formatter = new BinaryFormatter();
            using( FileStream bin = new FileStream( completePath, FileMode.Open, FileAccess.Read, FileShare.Read ) )
            {
                return (Form)formatter.Deserialize( bin );
            }
        }
    }
}
