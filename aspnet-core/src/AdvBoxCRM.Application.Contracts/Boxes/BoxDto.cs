using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AdvBoxCRM.Boxes
{
    public class BoxDto : EntityDto<Guid>
    {
        public string BoxNumber { get; set; }
        public bool CoverDefect { get; set; }
        public bool BoxCorrosion { get; set; }
        public bool BoxFullness { get; set; }
        public DateTime LastMaintenanceDate { get; set; }
        public BoxStatus Status { get; set; }
        public string BoxAdress { get; set; }
    }
}
