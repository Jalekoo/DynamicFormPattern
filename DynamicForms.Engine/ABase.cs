using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Engine
{
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

        public void Accept( IValidator validator )
        {
            validator.Valid( this );
        }
    }
}
