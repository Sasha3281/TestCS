using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCS3
{
    class ProblemsException : Exception 
    {
        public ProblemsException() { }

        public ProblemsException(string message)
            : base(message) { }

        public ProblemsException(string message, Exception inner)
            : base(message, inner) { }
    }
}
