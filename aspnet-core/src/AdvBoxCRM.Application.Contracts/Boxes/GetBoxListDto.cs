using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AdvBoxCRM.Boxes
{
    public class GetBoxListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
