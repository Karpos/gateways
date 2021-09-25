using Gateways.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateways.Data
{
    public interface IGatewaysRepo
    {
        public void CreateGateway(Gateway gateway);
        public List<Gateway> GetAllGateways();
        public Gateway GetGatewayById(string sn);
        public bool SaveChanges();
    }
}
