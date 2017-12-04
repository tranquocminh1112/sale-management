using System;
using System.Collections.Generic;
using System.Text;

namespace App.Common.Models
{
    public class BasicSearchCriteria : BasePagingRequest
    {
        public string Keyword { get; set; }
    }
}
