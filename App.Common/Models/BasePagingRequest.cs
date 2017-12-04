using System;
using System.Collections.Generic;
using System.Text;

namespace App.Common.Models
{
    public class BasePagingRequest
    {
        public DateTime? BaseSearchTime { get; set; }
        
        public int? Page { get; set; }
        public int? Length { get; set; }
    }
}
