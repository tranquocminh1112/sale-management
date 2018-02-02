using App.Common.Models;
using Microsoft.AspNetCore.Mvc;
using SaleManagement.Adapters;
using SaleManagement.Exception;
using SaleManagement.Models;
using SaleManagement.Models.BindingModels;
using SaleManagement.Models.ViewModels;
using SaleManagement.Resources;
using SaleManagement.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleManagement.Controllers
{
    [Route("api/customer")]
    public class CustomerController : Controller
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{id}")]
        public async Task<CustomerViewModel> GetAsync(int id)
        {
            var customer = await _customerService.GetAsync(id, true);
            if(customer == null)
            {
                throw new CustomException(Errors.CUSTOMER_NOT_FOUND, Errors.CUSTOMER_NOT_FOUND_MSG);
            }

            return customer.ToViewModel();
        }

        [HttpGet("search")]
        public async Task<BaseSearchResponse<CustomerViewModel>> Search([FromQuery]BasicSearchCriteria criteria)
        {
            var result = await _customerService.SearchAsync(criteria);

            return new BaseSearchResponse<CustomerViewModel>
            {
                SearchAt = result.SearchAt,
                Total = result.Total,
                Items = result.Items.Select(i => i.ToViewModel()).ToList()
            };
        }

        [HttpPost]
        public async Task<CustomerViewModel> CreateAsync([FromBody] CustomerCreateModel createModel)
        {
            var model = createModel.ToModel();

            var customer = await _customerService.CreateAsync(model);

            return customer.ToViewModel();
        }

        [HttpPut]
        public async Task UpdateAsync([FromBody] CustomerUpdateModel updateModel)
        {
            var model = updateModel.ToModel();

            await _customerService.UpdateAsync(model);
        }
    }
}
