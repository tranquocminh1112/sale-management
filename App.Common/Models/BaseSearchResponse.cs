using System;
using System.Collections.Generic;
using System.Text;

namespace App.Common.Models
{
    public class BaseSearchResponse<T>
    {
        public BaseSearchResponse()
        {
            Items = new List<T>();
        }

        public List<T> Items { get; set; }
        public int Total { get; set; }
        public DateTime SearchAt { get; set; }
    }
}
