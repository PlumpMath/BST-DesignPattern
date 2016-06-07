using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST.Exceptions
{
    public class KeyAlreadyExistException: Exception
    {
        public KeyAlreadyExistException()
        {
        }

        public KeyAlreadyExistException(string message)
            : base(message)
        { 
        }

        public KeyAlreadyExistException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
