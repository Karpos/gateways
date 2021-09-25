using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gateways.Models
{
    public class Device
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long UID{ get; set; }
        public string Vendor{ get; set; }
        public DateTime Date{ get; set; }
        public bool Status{ get; set; }
        public string? SerialNumber {  get; set; }
        public Gateway? Gateway { get; set; }
    }
}
