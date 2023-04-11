using AdvBoxCRM.Guests;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace AdvBoxCRM.Maintanances
{
    public class MaintananceManager : DomainService
    {
        
        
            private readonly IMaintananceRepository _maintananceRepository;

            public MaintananceManager(IMaintananceRepository maintananceRepository)
            {
                _maintananceRepository = maintananceRepository;
            }

            public async Task<Maintanance> CreateAsync(
                 Guid id,
                    [NotNull] Guid boxID,
                    [NotNull] Guid employeeID,
                    [NotNull] DateTime maintenanceDate)
            {
                return new Maintanance(
                    GuidGenerator.Create(),
                    boxID,
                    employeeID,
                    maintenanceDate
                    );
            }

        }
    }

