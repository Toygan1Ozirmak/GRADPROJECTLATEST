using AdvBoxCRM.Boxes;
using AdvBoxCRM.Employees;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace AdvBoxCRM.Guests
{
    public class GuestManager : DomainService
    {
        private readonly IGuestRepository _guestRepository;

        public GuestManager(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task<Guest> CreateAsync(
           Guid id, string guestName, string guestSurname, int guestPhone)
        {
            Check.NotNullOrWhiteSpace(guestName, nameof(guestName));

            var existingGuest = await _guestRepository.FindByNameAsync(guestName);
            if (existingGuest != null)
            {
                throw new GuestAlreadyExistsException(guestName);
            }

            return new Guest(


                GuidGenerator.Create(),
               guestName,
               guestSurname,
               guestPhone
               );
        }

        public async Task ChangeNameAsync(
            [NotNull] Guest guest,
            [NotNull] string newGuestName)
        {
            Check.NotNull(guest, nameof(guest));
            Check.NotNullOrWhiteSpace(newGuestName, nameof(newGuestName));

            var existingGuest = await _guestRepository.FindByNameAsync(newGuestName);
            if (existingGuest != null && existingGuest.Id != guest.Id)
            {
                throw new GuestAlreadyExistsException(newGuestName);
            }

            guest.ChangeGuestName(newGuestName);
        }
    }
}
