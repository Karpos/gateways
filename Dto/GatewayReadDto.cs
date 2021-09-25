using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Gateways.Dto
{
    public class GatewayReadDto 
    {
        public string SerialNumber{ get; set; }
        public string Name{ get; set; }
        public string IpAdress{ get; set; }

        
    }
}
