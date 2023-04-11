using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace AdvBoxCRM.Employees
{
    public class EmployeeAlreadyExistsException : BusinessException
    {
        public EmployeeAlreadyExistsException(string employeeName)
            : base(AdvBoxCRMDomainErrorCodes.EmployeeAlreadyExists)
        {
            WithData("employeeName", employeeName);
        }
    }
}
