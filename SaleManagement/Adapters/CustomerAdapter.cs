using SaleManagement.Models;
using SaleManagement.Models.BindingModels;
using SaleManagement.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleManagement.Adapters
{
    public static class CustomerAdapter
    {
        public static CustomerViewModel ToViewModel(this Customer model)
        {
            if (model == null) return null;

            return new CustomerViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                MainContactNumber = model.MainContactNumber,
                MainContactPerson = model.MainContactPerson,
                SubContactNumber = model.SubContactNumber,
                SubContactPerson = model.SubContactPerson,

                Debt = model.Debt,
                DebtOrder = model.DebtOrder,

                Credit = model.Credit,
                CreditOrder = model.CreditOrder,

                Area = model.Area
            };
        }

        public static Customer ToModel(this CustomerCreateModel model)
        {
            if (model == null) return null;

            return new Customer {
                Name = model.Name,
                Description = model.Description,
                MainContactNumber = model.MainContactNumber,
                MainContactPerson = model.MainContactPerson,
                SubContactNumber = model.SubContactNumber,
                SubContactPerson = model.SubContactPerson,
                Area = model.Area
            };
        }

        public static Customer ToModel(this CustomerUpdateModel model)
        {
            if (model == null) return null;

            return new Customer
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                MainContactNumber = model.MainContactNumber,
                MainContactPerson = model.MainContactPerson,
                SubContactNumber = model.SubContactNumber,
                SubContactPerson = model.SubContactPerson,
                Area = model.Area
            };
        }
    }
}
