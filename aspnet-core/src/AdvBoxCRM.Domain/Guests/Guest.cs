using AdvBoxCRM.Employees;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace AdvBoxCRM.Guests
{
    public class Guest : FullAuditedAggregateRoot<Guid>
    {
        public string GuestName { get; set; }
        public string GuestSurname { get; set; }
        public int GuestPhone { get; set; }

        private Guest()
        {

        }

        internal Guest(Guid id, string guestName, string guestSurname, int guestPhone)
            : base(id)
            

        {
            GuestName = guestName;
            GuestSurname = guestSurname;
            GuestPhone = guestPhone;

                    
        }

        internal Guest ChangeGuestName([NotNull] string guestName)
        {
            SetGuestName(guestName);
            return this;
        }

        private void SetGuestName([NotNull] string guestName)
        {
            GuestName = Check.NotNullOrWhiteSpace(
                guestName,
                nameof(guestName),
                maxLength: 25
            );
        }

    }
}
