using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Application.Responses
{
    public class ApiResponseModel<T>
    {
        public T? Data { get; }

        public bool Success { get; }

        public ApiResponseModel(T? data, int? total = null, bool success = true)
        {
            Success = success;
            Data = data;
        }
    }
}
