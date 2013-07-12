using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForms.Engine;

namespace DynamicForms.Components
{
    public class AMultipleChoice : ABase
    {
        readonly List<Choice> _choices;
        public AMultipleChoice( QBase question )
            : base( question )
        {
            _choices = new List<Choice>();
        }

        public void AddANewAnswer( Choice choice )
        {
            QMultipleChoice m = (QMultipleChoice)Question;
            if( m.Choices.Contains( choice ) )
            {
                if( _choices.Count < m.Max ) _choices.Add( choice );
                else throw new ApplicationException( "Could not add this choice : limit attempt" );
            }
            else throw new ApplicationException( "Could not add this choice : it's not a question's choice" );
        }

        public bool HasMinimalAnswers { get { return _choices.Count < ((QMultipleChoice)Question).Min; } }
    }
}
