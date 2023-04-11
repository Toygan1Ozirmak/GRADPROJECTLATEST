using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdvBoxCRM.Guests
{
    public class CreateGuestDto
    {
        [Required]
        [MaxLength(50)]
        public string GuestName { get; set; }
        [Required]
        [MaxLength(50)]
        public string GuestSurname { get; set; }
        [Required, MaxLength(11)]
        public int GuestPhone { get; set; }
    }
}
