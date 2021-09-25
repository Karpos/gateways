using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Gateways.Exceptions
{
    [Serializable]
    public class DuplicateGatewayException : Exception
    {
        public DuplicateGatewayException() {  }

        public DuplicateGatewayException(string serialNumber)
            : base(String.Format("Gateway with UID: {0} is allredy on Gateway", serialNumber))
        {

        }   
    }
}
