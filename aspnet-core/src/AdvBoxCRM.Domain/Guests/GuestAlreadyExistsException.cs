using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace AdvBoxCRM.Guests
{
    public class GuestAlreadyExistsException : BusinessException
    {
        public GuestAlreadyExistsException(string guestName)
            : base(AdvBoxCRMDomainErrorCodes.GuestAlreadyExists)
        {
            WithData("guestName", guestName);
        }
    }
}
