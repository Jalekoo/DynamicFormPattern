using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Engine
{
    public class Form
    {
        public Form( string name )
        {
            Name = name;

            Questions = new List<QBase>();
            Sheets = new List<AnswerSheet>();
        }

        public string Name { get; set; }

        public IList<QBase> Questions { get; set; }

        public IList<AnswerSheet> Sheets { get; set; }

        public T AddANewQuestion<T>( string title, bool isRequired ) where T : QBase
        {
            T q = (T)Activator.CreateInstance( typeof( T ), title, isRequired );
            Questions.Add( q );
            return q;
        }

        public AnswerSheet FindOrCreateAnswerSheet( string name )
        {
            AnswerSheet a = FindAnswerSheet( name );
            if( a == null ) a = CreateAnswerSheet( name );
            return a;
        }

        private AnswerSheet CreateAnswerSheet( string name )
        {
            AnswerSheet a = new AnswerSheet( name, this );
            Sheets.Add( a );
            return a;
        }

        private AnswerSheet FindAnswerSheet( string name )
        {
            return Sheets.SingleOrDefault( a => a.UniqueName == name );
        }
    }
}
