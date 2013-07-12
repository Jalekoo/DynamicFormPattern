using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Engine
{
    [Serializable]
    public abstract class ABase
    {
        readonly QBase _question;
        readonly DateTime _creationTime;

        public ABase( QBase question )
        {
            _question = question;
            _creationTime = DateTime.UtcNow;
        }

        public DateTime Date { get { return _creationTime; } }

        public QBase Question { get { return _question; } }

        // Début d'implémentation du pattern du valiadtor, je n'ai pas encore tout compris alors je vais continuer de potasser !
        public void Accept( IValidator validator )
        {
            validator.Valid( this );
        }
    }
}
