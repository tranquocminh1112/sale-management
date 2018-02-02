using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace App.Common.Exceptions
{
    public class CustomException : Exception
    {
        public string Code { get; set; }

        /// <summary>
        /// using when you want to return your model
        /// </summary>
        public object Obj { get; set; }

        /// <summary>
        /// It is true when you want to return your model
        /// </summary>
        public bool IsThrowCustomModel { get; set; }

        /// <summary>
        /// using when you want to return with status code = 401
        /// </summary>
        public bool IsUnauthorized { get; set; }

        public CustomException(string code, string message = null, bool isUnauthorized = false) : base(message ?? code)
        {
            Code = code;
            IsUnauthorized = isUnauthorized;
        }

        public CustomException(object obj) : base()
        {
            Obj = obj;
            IsThrowCustomModel = true;
        }

        public override string ToString()
        {
            if (IsThrowCustomModel)
            {
                return JsonConvert.SerializeObject(Obj);
            }

            return JsonConvert.SerializeObject(new {
                Code = Code,
                Message = Message
            });
        }
    }
}
