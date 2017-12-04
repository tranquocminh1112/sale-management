using SaleManagement.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Common.Models;
using SaleManagement.Models;

namespace SaleManagement.Services
{
    public class TransporterService : ITransporterService
    {
        public Task<Transporter> CreateAsync(Transporter transporter)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Transporter> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseSearchResponse<Transporter>> SearchAsync(BasicSearchCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Transporter transporter)
        {
            throw new NotImplementedException();
        }
    }
}
