using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdvBoxCRM.Maintanances
{
    public class CreateMaintananceDto
    {
        [Required]
        public Guid BoxID { get; set; }
        [Required]
        public Guid EmployeeID { get; set; }
        [Required]
        public DateTime MaintenanceDate { get; set; }
    }
}
