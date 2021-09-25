using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Gateways.Exceptions
{
    [Serializable]
    public class GatewayNotExistisException : Exception
    {
        public GatewayNotExistisException() {  }

        public GatewayNotExistisException(string serialNumber)
            : base(String.Format("Gateway with serial number: {0} do not exists", serialNumber))
        {

        }   
    }
}
