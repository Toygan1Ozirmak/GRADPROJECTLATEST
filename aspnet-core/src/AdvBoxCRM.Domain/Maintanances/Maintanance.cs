using AdvBoxCRM.Boxes;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace AdvBoxCRM.Maintanances
{
    public class Maintanance : FullAuditedAggregateRoot<Guid>
    {
        public Guid BoxID { get; set; }
       
        public Guid EmployeeID { get; set; }
        public DateTime MaintenanceDate { get; set; }

        private Maintanance()
        {

        }

        internal Maintanance(
                    Guid id,
                    [NotNull] Guid boxID,
                    [NotNull] Guid employeeID,
                    [NotNull] DateTime maintenanceDate
                    )
                    : base(id)
        {
            
           
            BoxID = boxID;
            EmployeeID = employeeID;
            MaintenanceDate = maintenanceDate;        

        }
       
    }







}
