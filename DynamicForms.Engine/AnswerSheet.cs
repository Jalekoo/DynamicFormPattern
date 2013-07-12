using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Engine
{
    [Serializable]
    public class AnswerSheet
    {
        readonly Form _form;
        readonly IDictionary<QBase, ABase> _answers;

        public AnswerSheet( string name, Form form )
        {
            UniqueName = name;
            _form = form;

            _answers = new Dictionary<QBase, ABase>();
        }

        public string UniqueName { get; set; }

        public IDictionary<QBase, ABase> Answers
        {
            get
            {
                return _answers;
            }
        }

        public Form Form { get { return _form; } }

        public ABase CreateAnswerFor( QBase question )
        {
            ABase a = question.CreateAnswer( _form );
            Answers[question] = a;
            return a;
        }

        public ABase FindAnswerFor( QBase question )
        {
            return _answers[question];
        }
    }
}
