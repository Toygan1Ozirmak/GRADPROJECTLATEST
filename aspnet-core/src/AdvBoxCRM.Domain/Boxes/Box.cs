using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace AdvBoxCRM.Boxes
{
    public class Box : FullAuditedAggregateRoot<Guid>
    {
        public string BoxNumber { get; set; }
        public bool CoverDefect { get; set; }
        public bool BoxCorrosion { get; set; }
        public bool BoxFullness { get; set; }
        public DateTime LastMaintenanceDate { get; set; }
        public  BoxStatus Status { get; set; }
        public string BoxAdress { get; set; }


       // public Guid EmployeeID { get; set; }
        // public Guid MaintananceID { get; set; } 

        //Bakım Tablosu Id gelmeli
        // Bakımı yapan kişinin Adı

        private Box()
        {
        }
        internal Box(Guid id, string boxNumber, bool coverDefect, bool boxCorrosion, bool boxFullness, DateTime lastMaintenanceDate,
            BoxStatus status, string boxAdress)
        :base(id)
        {
        
        BoxNumber = boxNumber;
            CoverDefect = coverDefect;
            BoxCorrosion = boxCorrosion;
            BoxFullness = boxFullness;
            LastMaintenanceDate = lastMaintenanceDate;
            Status = status;
            BoxAdress = boxAdress;
   
        
        }
        internal Box ChangeAdress([NotNull] string boxAdress)
        {
            SetAdress(boxAdress);
            return this;
        }

        private void SetAdress([NotNull] string boxAdress)
        {
            BoxAdress = Check.NotNullOrWhiteSpace(
                boxAdress,
                nameof(boxAdress),
                maxLength: 250
            ) ;
        }







    }
}
