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
        }

        public string Name { get; set; }

        public IList<QBase> Questions { get; set; }

        public IList<AnswerSheet> Sheets { get; set; }

        public QBase AddANewQuestion( Type questionType, string title, bool isRequired )
        {
            QBase q = (QBase)Activator.CreateInstance( questionType, title, isRequired );
            Questions.Add( q );
            return q;
        }

        public AnswerSheet FindOrCreateAnswerSheet( string name )
        {
            AnswerSheet a = new AnswerSheet( name, this );
            Sheets.Add( a );
            return a;
        }
    }
}
