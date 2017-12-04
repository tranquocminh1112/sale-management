using App.Common.Models;
using SaleManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleManagement.ServiceInterfaces
{
    public interface ITagService
    {
        Task<Tag> GetAsync(int id);
        Task<Tag> CreateAsync(Tag tag);
        Task UpdateAsync(Tag tag);
        Task DeleteAsync(int id);
        Task<BaseSearchResponse<Tag>> SearchAsync(BasicSearchCriteria criteria);
    }
}
