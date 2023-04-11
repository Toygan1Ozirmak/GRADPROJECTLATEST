using AdvBoxCRM.Guests;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AdvBoxCRM.Maintanances
{
    public interface IMaintananceAppService : IApplicationService
    {
        Task<MaintananceDto> CreateMaintananceAsync(CreateMaintananceDto input);
        Task<PagedResult<MaintananceDto>> GetListAsync(GetGuestListDto input);
        Task<MaintananceDto> GetAsync(Guid id);
    }
}
