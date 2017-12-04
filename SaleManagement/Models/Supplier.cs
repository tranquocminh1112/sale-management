using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SaleManagement.Models
{
    public class Supplier : BaseObject
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string MainContactNumber { get; set; }
        public string MainContactPerson { get; set; }
        public string SubContactNumber { get; set; }
        public string SubContactPerson { get; set; }

        public List<Product> Products { get; set; }

        public ObjectStatus Status { get; set; }
    }
}
