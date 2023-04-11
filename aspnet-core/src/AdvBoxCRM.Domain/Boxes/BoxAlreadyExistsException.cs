using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace AdvBoxCRM.Boxes
{
    public class BoxAlreadyExistsException : BusinessException
    {
        public BoxAlreadyExistsException(string boxAdress)
            : base(AdvBoxCRMDomainErrorCodes.BoxAlreadyExists)
        {
            WithData("boxAdress", boxAdress);
        }
    }
}
