﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AdvBoxCRM.Employees
{
    public class GetEmployeeListDto : PagedAndSortedResultRequestDto
    {
        public string Filter  { get; set; }
    }
}
