using Gateways.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateways.Data
{
    public interface IDevicesRepo
    {
        public void CreateDevice(Device gateway);
        public List<Device> GetAllDevices();
        public Device GetDeviceById(long sn);
        public List<Device> GetDevicesPerGateway(string serialNumber);
        public void AddDeviceOnGateway(string serialNumber, long uid);
        public void RemoveDeviceFromGateway(string serialNumber, long uid);
        public bool SaveChanges();
    }
}
