using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AdvBoxCRM.Guests
{
    public class GuestDto : EntityDto<Guid>
    {
        public string GuestName { get; set; }
        public string GuestSurname { get; set; }
        public int GuestPhone { get; set; }
    }
}
