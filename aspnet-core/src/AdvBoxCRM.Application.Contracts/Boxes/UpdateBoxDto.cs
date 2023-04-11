using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdvBoxCRM.Boxes
{
    public class UpdateBoxDto
    {
        //[Required]
        //[MaxLength(10)]
       // public string BoxNumber { get; set; }
        [Required]
        public bool CoverDefect { get; set; }

        [Required]
        public bool BoxCorrosion { get; set; }
        [Required]
        public bool BoxFullness { get; set; }
        [Required]
        public DateTime LastMaintenanceDate { get; set; }
        [Required]
        public BoxStatus Status { get; set; }
        [Required]
        public string BoxAdress { get; set; }
    }
}

