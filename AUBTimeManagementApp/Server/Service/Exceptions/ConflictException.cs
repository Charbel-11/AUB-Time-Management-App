using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.Exceptions
{
    public class ConflictException : Exception
    {
        public List<int> ConflictingEvents;
        public string ConflictMessage;
        public ConflictException(string message, List<int> conflictingEvents)
        {
            ConflictingEvents = conflictingEvents;
            ConflictMessage = message;
        }
    }
}
