using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace AdvBoxCRM.Employees
{
    public class Employee : FullAuditedAggregateRoot<Guid>
    {
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string EmployeeSurname { get; set; }
        [Required]
        public string Email { get; set; }
        public int EmployeePhone { get; set; }
       
     private Employee()
        {

        }
     internal Employee(Guid id, string employeeName, string employeeSurname, string email, int employeePhone)  :
            base(id)
        {
            EmployeeName = employeeName;
                
            EmployeeSurname = employeeSurname;
            Email = email;
            EmployeePhone = employeePhone;
                
        }

        internal Employee ChangeEmployeeName([NotNull] string employeeName)
        {
            SetEmployeeName(employeeName);
            return this;
        }

        private void SetEmployeeName([NotNull] string employeeName)
        {
            EmployeeName = Check.NotNullOrWhiteSpace(
                employeeName,
                nameof(employeeName),
                maxLength: 25
            );
        }



    }


   
}
