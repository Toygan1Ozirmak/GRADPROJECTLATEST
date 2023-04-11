using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Guids;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace AdvBoxCRM.Boxes
{
    public class BoxManager : DomainService
    {
        private readonly IBoxRepository _boxRepository;

        public BoxManager(IBoxRepository boxRepository)
        {
            _boxRepository = boxRepository;
        }

        public async Task<Box> CreateAsync(
           Guid id, string boxNumber, bool coverDefect, bool boxCorrosion, bool boxFullness, DateTime lastMaintenanceDate,
            BoxStatus status, string boxAdress)
        {
            Check.NotNullOrWhiteSpace(boxAdress, nameof(boxAdress));

            var existingBox = await _boxRepository.FindByBoxAdressAsync(boxAdress);
            if (existingBox != null)
            {
                throw new BoxAlreadyExistsException(boxAdress);
            }

            return new Box(
               
                
                GuidGenerator.Create(),
                boxNumber,
                coverDefect,
                boxCorrosion,
                boxFullness,
                lastMaintenanceDate,
                status,
                boxAdress
            );
        }

        public async Task ChangeBoxAdressAsync(
            [NotNull] Box box,
            [NotNull] string newBoxAdress)
        {
            Check.NotNull(box, nameof(box));
            Check.NotNullOrWhiteSpace(newBoxAdress, nameof(newBoxAdress));

            var existingBox = await _boxRepository.FindByBoxAdressAsync(newBoxAdress);
            if (existingBox != null && existingBox.Id != box.Id)
            {
                throw new BoxAlreadyExistsException(newBoxAdress);
            }

            box.ChangeAdress(newBoxAdress);
        }
    }
}
