using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Engine
{
    public class AnswerSheet
    {
        readonly Form _form;

        public AnswerSheet( string name, Form form )
        {
            UniqueName = name;
            _form = form;

            Answers = new List<ABase>();
        }

        public string UniqueName { get; set; }

        public IList<ABase> Answers { get; set; }

        public Form Form { get { return _form; } }

        public ABase FindOrCreateAnswerFor( QBase question )
        {
            ABase a = (ABase)Activator.CreateInstance( question.AnswerType, question );
            Answers.Add( a );
            return a;
        }
    }
}
