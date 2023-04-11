using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AdvBoxCRM.Boxes
{
    public interface IBoxRepository : IRepository<Box, Guid>
    {
    
        Task<Box> FindByBoxAdressAsync(string boxAdress);

    Task<List<Box>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null
    );
}
}
