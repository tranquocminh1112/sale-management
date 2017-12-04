using App.Common.Models;
using SaleManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleManagement.ServiceInterfaces
{
    public interface ITransporterService
    {
        Task<Transporter> GetAsync(int id);
        Task<Transporter> CreateAsync(Transporter transporter);
        Task UpdateAsync(Transporter transporter);
        Task DeleteAsync(int id);
        Task<BaseSearchResponse<Transporter>> SearchAsync(BasicSearchCriteria criteria);
    }
}
