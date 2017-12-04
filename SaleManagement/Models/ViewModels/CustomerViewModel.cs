using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleManagement.Models.ViewModels
{
    public class CustomerViewModel
    {
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
    }
}
