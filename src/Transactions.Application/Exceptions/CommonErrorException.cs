using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Application.Exceptions
{
    public class CommonErrorException : Exception
    {
        public CommonErrorException(string message, params object[] args)
            : base(string.Format(message, args))
        {
        }
    }
}
