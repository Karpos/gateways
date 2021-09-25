using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Gateways.Exceptions
{
    [Serializable]
    public class DeviceNotExistisException : Exception
    {
        public DeviceNotExistisException() {  }

        public DeviceNotExistisException(long UID)
            : base(String.Format("Device with UID: {0} do not exists", UID))
        {

        }   
    }
}
