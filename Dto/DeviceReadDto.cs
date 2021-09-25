using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Gateways.Dto
{
    public class DeviceReadDto 
    {
        public long UID{ get; set; }
        public string Vendor{ get; set; }
        public DateTime Date{ get; set; }
        public string Status{ get; set; }
        public string SerialNumber{ get; set; }

    }
}
