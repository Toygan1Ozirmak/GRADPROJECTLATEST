using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AdvBoxCRM.Guests
{
    public interface IGuestAppService : IApplicationService
    {
        Task<GuestDto> CreateGuest(CreateGuestDto input);
        Task<PagedResult<GuestDto>> GetListAsync(GetGuestListDto input);
        Task<GuestDto> GetGuestAsync(Guid id);
    }
}
