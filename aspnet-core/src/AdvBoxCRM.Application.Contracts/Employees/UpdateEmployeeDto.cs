using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdvBoxCRM.Employees
{
    public class UpdateEmployeeDto
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
