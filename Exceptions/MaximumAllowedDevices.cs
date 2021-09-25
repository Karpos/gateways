using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Gateways.Exceptions
{
    [Serializable]
    public class MaximumAllowedDevicesException : Exception
    {
        public MaximumAllowedDevicesException() {  }

        public MaximumAllowedDevicesException(string serialNumber)
            : base(String.Format("Maximum allowed devices on channel is 10. Channel serial number: {0}", serialNumber))
        {

        }   
    }
}
