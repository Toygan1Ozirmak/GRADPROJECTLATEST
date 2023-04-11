using AdvBoxCRM.Boxes;
using AdvBoxCRM.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ADVBoxCRM.Maintanances
{
    public class EfCoreMaintananceRepository
        : EfCoreRepository<AdvBoxCRMDbContext, Guest, Guid>,
            IMaintananceRepository
    {
        public EfCoreMaintananceRepository(
            IDbContextProvider<AdvBoxCRMDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<Maintanance> FindByDateAsync(string MaintananceDate)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(Maintanance => Maintanance.MaintananceDate == MaintananceDate);
        }

        public async Task<List<Maintanance>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    maintanance => maintanance.MaintananceName.Contains(filter)
                 )
                //.OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();

        }
    }
}
