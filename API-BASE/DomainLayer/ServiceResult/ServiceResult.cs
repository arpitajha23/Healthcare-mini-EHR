using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ServiceResult
{
    public class ServiceResult
    {
        public string Success { get; set; }
        public string Message { get; set; }
        public string Data { get; set; }

        public ServiceResult(string success, string message, string data = default)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
