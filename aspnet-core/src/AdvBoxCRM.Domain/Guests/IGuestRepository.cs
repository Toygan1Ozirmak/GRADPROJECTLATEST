using AdvBoxCRM.Boxes;
using AdvBoxCRM.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AdvBoxCRM.Guests
{
    public interface IGuestRepository : IRepository<Guest, Guid>
    {
        Task<Employee> FindByNameAsync(string employeeName);

        Task<List<Employee>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
