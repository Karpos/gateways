using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Gateways.Dto
{
    public class DeviceCreateDto 
    {                
        public long UID{ get; set; }
        public string Vendor{ get; set; }
        public DateTime Date{ get; set; }
        public bool Status{ get; set; }
    }
}
