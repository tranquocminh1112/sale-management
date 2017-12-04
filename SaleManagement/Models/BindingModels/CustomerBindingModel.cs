using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleManagement.Models.BindingModels
{
    public class CustomerCreateModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string MainContactNumber { get; set; }
        public string MainContactPerson { get; set; }
        public string SubContactNumber { get; set; }
        public string SubContactPerson { get; set; }

        public Area Area { get; set; }
    }

    public class CustomerUpdateModel : CustomerCreateModel
    {
        public int Id { get; set; }
    }
}
