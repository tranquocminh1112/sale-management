using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SaleManagement.Models
{
    public class Customer : BaseObject
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MainContactNumber { get; set; }
        public string MainContactPerson { get; set; }
        public string SubContactNumber { get; set; }
        public string SubContactPerson { get; set; }

        public double Debt { get; set; }
        public Order DebtOrder { get; set; }

        public double Credit { get; set; }
        public Order CreditOrder { get; set; }

        public Area Area { get; set; }
        public List<Transporter> Transporters { get; set; }
        public List<Order> Orders { get; set; }

        public ObjectStatus Status { get; set; }
    }
}
