using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AdvBoxCRM.Employees
{
    public class EmployeeDto : EntityDto<Guid>
    {
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string EmployeeSurname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int EmployeePhone { get; set; }
        
    }
}
