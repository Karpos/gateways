using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gateways.Models
{
    public class Gateway
    {
        [Key]
        public string SerialNumber{ get; set; }
        public string Name{ get; set; }
        [RegularExpression(@"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$")]
        public string IpAdress{ get; set; }
        public ICollection<Device> Devices{ get; set; }
    }
}
