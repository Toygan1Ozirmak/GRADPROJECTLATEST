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

namespace ADVBoxCRM.Guests
{
    public class EfCoreGuestRepository
        : EfCoreRepository<AdvBoxCRMDbContext, Guest, Guid>,
            IGuestRepository
    {
        public EfCoreGuestRepository(
            IDbContextProvider<AdvBoxCRMDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<Guest> FindByBoxNameAsync(string GuestName)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(Guest => Guest.GuestName == GuestName);
        }

        public async Task<List<Guest>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    guest => guest.GuestName.Contains(filter)
                 )
                //.OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();

        }
    }
}
