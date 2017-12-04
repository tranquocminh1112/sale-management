using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleManagement.Exception
{
    public class CustomException : System.Exception
    {
        public string Code { get; set; }

        public bool IsUnauthorized { get; set; }

        public List<string> Codes { get; set; }

        public CustomException(string code, string message = null, bool isUnauthorized = false) : base(message ?? code)
        {
            this.Code = code;
            this.IsUnauthorized = isUnauthorized;
        }

        public CustomException(List<string> codes) : base()
        {
            Codes = codes;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(new
            {
                Code = this.Code,
                Codes = Codes,
                Message = this.Message
            });
        }
    }
}
