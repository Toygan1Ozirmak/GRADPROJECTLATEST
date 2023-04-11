using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AdvBoxCRM.Employees
{
    public interface IEmployeeAppService : IApplicationService
    {
        Task<EmployeeDto> CreateAsync(CreateEmployeeDto input);
        Task<EmployeeDto> UpdateAsync(Guid id, UpdateEmployeeDto input);
        Task DeleteAsync(Guid id);
        Task<EmployeeDto> GetAsync(Guid id);
        Task<PagedResult<EmployeeDto>> GetListAsync(GetEmployeeListDto input);
     
                
    }
}
