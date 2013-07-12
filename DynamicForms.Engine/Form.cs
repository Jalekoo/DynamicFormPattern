using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Engine
{
    public class Form
    {
        readonly QRoot _root;

        public Form( string name )
        {
            Name = name;

            _root = new QRoot( this, "Root", true, null );
            Sheets = new List<AnswerSheet>();
        }

        public string Name { get; set; }

        public IList<AnswerSheet> Sheets { get; set; }

        public QRoot Questions { get { return _root; } }

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
