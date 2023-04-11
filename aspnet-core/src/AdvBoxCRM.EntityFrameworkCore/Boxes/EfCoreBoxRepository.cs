using AdvBoxCRM.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AdvBoxCRM.Boxes
{
    
        public class EfCoreBoxRepository
        : EfCoreRepository<AdvBoxCRMDbContext, Box, Guid>,
            IBoxRepository
        {
            public EfCoreBoxRepository(
                IDbContextProvider<AdvBoxCRMDbContext> dbContextProvider)
                : base(dbContextProvider)
            {
            }

            public async Task<Box> FindByBoxAdressAsync(string boxAdress)
            {
                var dbSet = await GetDbSetAsync();
                return await dbSet.FirstOrDefaultAsync(Box => Box.BoxAdress == boxAdress);
            }

            public async Task<List<Box>> GetListAsync(
                int skipCount,
                int maxResultCount,
                string sorting,
                string filter = null)
            {
                var dbSet = await GetDbSetAsync();
                return await dbSet
                    .WhereIf(
                        !filter.IsNullOrWhiteSpace(),
                        box => box.BoxAdress.Contains(filter)
                     )
                    //.OrderBy(sorting)
                    .Skip(skipCount)
                    .Take(maxResultCount)
                    .ToListAsync();

            }
        }
    }
