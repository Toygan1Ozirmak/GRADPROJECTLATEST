using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace AdvBoxCRM.Boxes
{
    public class BoxAppService : AdvBoxCRMAppService, IBoxAppService
    {
        private readonly IBoxRepository _boxRepository;
        private readonly BoxManager _boxManager;

        public BoxAppService(
            IBoxRepository boxRepository,
            BoxManager boxManager)
        {
            _boxRepository = boxRepository;
            _boxManager = boxManager;
        }

        public async Task<  BoxDto> GetAsync(Guid id)
        {
            var box = await _boxRepository.GetAsync(id);
            return ObjectMapper.Map<Box, BoxDto>(box);
        }

        public async Task<PagedResultDto<BoxDto>> GetListAsync(GetBoxListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Box.BoxNumber);
            }

            var boxes = await _boxRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount = input.Filter == null
                ? await _boxRepository.CountAsync()
                : await _boxRepository.CountAsync(
                    box => box.BoxNumber.Contains(input.Filter));

            return new PagedResultDto<BoxDto>(
                totalCount,
                ObjectMapper.Map<List<Box>, List<BoxDto>>(boxes)
            );
        }
        public async Task<BoxDto> CreateAsync(CreateBoxDto input)
        {
            var box = await _boxManager.CreateAsync(
                Guid.NewGuid(),
                input.BoxNumber,
                input.CoverDefect,
                input.BoxCorrosion,
                input.BoxFullness,
                input.LastMaintenanceDate,
               BoxStatus.Green,
               input.BoxAdress
            );

            await _boxRepository.InsertAsync(box);

            return ObjectMapper.Map<Box, BoxDto>(box);
        }
        public async Task UpdateAsync(Guid id, UpdateBoxDto input)
        {
            var box = await _boxRepository.GetAsync(id);

            if (box.BoxAdress != input.BoxAdress)
            {
                await _boxManager.ChangeBoxAdressAsync(box, input.BoxAdress);
            }

            box.BoxAdress = input.BoxAdress;

            await _boxRepository.UpdateAsync(box);
        }
        public async Task DeleteAsync(Guid id)
        {
            await _boxRepository.DeleteAsync(id);
        }

        //...SERVICE METHODS WILL COME HERE...
    }
}
