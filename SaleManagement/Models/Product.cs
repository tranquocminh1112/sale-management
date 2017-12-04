using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SaleManagement.Models
{
    public class Product : BaseObject
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public double Price { get; set; }
        public int? Quantity { get; set; }

        public Type Type { get; set; }
        public Supplier Supplier { get; set; }
        public Group Group { get; set; }
        public Company Company { get; set; }
        public List<Order> Orders { get; set; }

        public ObjectStatus Status { get; set; }
    }
}
