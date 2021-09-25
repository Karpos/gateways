using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Gateways.Exceptions
{
    [Serializable]
    public class DuplicateDeviceException : Exception
    {
        public DuplicateDeviceException() {  }

        public DuplicateDeviceException(long UID)
            : base(String.Format("Device with UID: {0} is allredy on Gateway", UID))
        {

        }   
    }
}
