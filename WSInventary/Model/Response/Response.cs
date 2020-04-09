using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSInventary.Model.Response
{
    public class Response
    {
        public Response()
        {
            this.Success = 0;
        }
        public int Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
