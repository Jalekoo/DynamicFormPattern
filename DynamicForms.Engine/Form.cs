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

        public AnswerSheet FindOrCreateAnswerSheetFor( string name )
        {
            AnswerSheet a = FindAnswerSheet( name );
            if( a == null ) a = CreateAnswerSheetInternalFor( name );
            return a;
        }

        private AnswerSheet CreateAnswerSheetInternalFor( string name )
        {
            AnswerSheet a = new AnswerSheet( name, this );
            Sheets.Add( a );
            return a;
        }

        public AnswerSheet FindAnswerSheet( string name )
        {
            return Sheets.SingleOrDefault( a => a.UniqueName == name );
        }

        public AnswerSheet CreateAnswerSheetFor(string name)
        {
            if( FindAnswerSheet( name ) != null ) throw new ArgumentException( "This name already exists !", "name" );
            return CreateAnswerSheetInternalFor( name );
        }
    }
}
