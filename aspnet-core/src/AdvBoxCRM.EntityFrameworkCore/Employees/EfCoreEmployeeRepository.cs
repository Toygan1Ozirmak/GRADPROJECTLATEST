using AdvBoxCRM.Boxes;
using AdvBoxCRM.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AdvBoxCRM.Employees
{
    public class EfCoreEmployeeRepository
         : EfCoreRepository<AdvBoxCRMDbContext, Employee, Guid>,
             IEmployeeRepository
    {
        public EfCoreEmployeeRepository(
            IDbContextProvider<AdvBoxCRMDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<Employee> FindByNameAsync(string employeeName)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(Employee => Employee.EmployeeName == employeeName);
        }

        public async Task<List<Employee>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    employee => employee.EmployeeName.Contains(filter)
                 )
                //.OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();

        }
    }
}
