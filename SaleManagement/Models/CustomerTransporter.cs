using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleManagement.Models
{
    public class CustomerTransporter : BaseObject
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int TransporterId { get; set; }
        public Transporter Transporter { get; set; }
    }
}
