using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AdvBoxCRM.Maintanances
{
    public interface IMaintananceRepository : IRepository<Maintanance, Guid>
    {
        Task<List<Maintanance>> GetListAsync(
           int skipCount,
           int maxResultCount,
           string sorting,
           string filter = null);
    }
}
