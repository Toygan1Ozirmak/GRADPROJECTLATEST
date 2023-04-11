using AdvBoxCRM.Boxes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AdvBoxCRM.Maintanances
{
    public class MaintananceDto : EntityDto<Guid>
    {
        public Guid BoxID { get; set; }
        public string BoxNumber { get; set; }
        public bool CoverDefect { get; set; }
        public bool BoxCorrosion { get; set; }
        public bool BoxFullness { get; set; }
        public DateTime LastMaintenanceDate { get; set; }
        public BoxStatus Status { get; set; }
        public string BoxAdress { get; set; }
        public Guid EmployeeID { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string EmployeeSurname { get; set; }
        [Required]
        public DateTime MaintenanceDate { get; set; }

    }
}
