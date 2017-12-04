using SaleManagement.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Common.Models;
using System.Text.RegularExpressions;

namespace SaleManagement.Services
{
    public class GroupService : IGroupService
    {
        public Task<Group> CreateAsync(Group group)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Group> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseSearchResponse<Group>> SearchAsync(BasicSearchCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Group group)
        {
            throw new NotImplementedException();
        }
    }
}
