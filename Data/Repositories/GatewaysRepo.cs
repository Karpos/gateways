using Gateways.Data.Repositories;
using Gateways.Exceptions;
using Gateways.Models;
using System.Collections.Generic;
using System.Linq;

namespace Gateways.Data
{
    public class GatewaysRepo : BaseRepository, IGatewaysRepo
    {
        private readonly GatewaysContext _context;

        public GatewaysRepo(GatewaysContext context): base(context)
        {
            _context = context;
        }
        public List<Gateway> GetAllGateways() => _context.Gateways.ToList();

        public Gateway GetGatewayById(string sn) => _context.Gateways.FirstOrDefault(g => g.SerialNumber == sn);

        public void CreateGateway(Gateway gateway)
        {
            if(gateway != null)
            {
                var gw = _context.Gateways.FirstOrDefault(g => g.SerialNumber == gateway.SerialNumber);

                if(gw != null) throw new DuplicateGatewayException(gateway.SerialNumber);

                _context.Gateways.Add(gateway);
            }
            
        }    
     
    }
}
