using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AdvBoxCRM.Boxes
{
    public interface IBoxAppService : IApplicationService
    {
        Task<BoxDto> CreateAsync(CreateBoxDto input);
        Task UpdateAsync(Guid id, UpdateBoxDto input);
        Task DeleteAsync(Guid id);
        Task<BoxDto> GetAsync(Guid id);

        Task<PagedResultDto<BoxDto>> GetListAsync(GetBoxListDto input);
        
    }
}
