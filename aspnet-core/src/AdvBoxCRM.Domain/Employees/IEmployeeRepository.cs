using AdvBoxCRM.Boxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AdvBoxCRM.Employees
{
    public interface IEmployeeRepository : IRepository<Employee, Guid>
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
