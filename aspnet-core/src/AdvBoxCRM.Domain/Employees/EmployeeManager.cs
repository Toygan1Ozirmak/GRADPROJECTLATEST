using AdvBoxCRM.Boxes;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace AdvBoxCRM.Employees
{
    public class EmployeeManager : DomainService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> CreateAsync(
           Guid id, string employeeName, string employeeSurname, string email, int employeePhone)
        {
            Check.NotNullOrWhiteSpace(employeeName, nameof(employeeName));

            var existingEmployee = await _employeeRepository.FindByNameAsync(employeeName);
            if (existingEmployee != null)
            {
                throw new EmployeeAlreadyExistsException(employeeName);
            }

            return new Employee(


                GuidGenerator.Create(),
               employeeName,
               employeeSurname, 
               email,
               employeePhone
            );
        }

        public async Task ChangeNameAsync(
            [NotNull] Employee employee,
            [NotNull] string newEmployeeName)
        {
            Check.NotNull(employee, nameof(employee));
            Check.NotNullOrWhiteSpace(newEmployeeName, nameof(newEmployeeName));

            var existingEmployee = await _employeeRepository.FindByNameAsync(newEmployeeName);
            if (existingEmployee != null && existingEmployee.Id != employee.Id)
            {
                throw new BoxAlreadyExistsException(newEmployeeName);
            }

            employee.ChangeEmployeeName(newEmployeeName);
        }
    }
}
