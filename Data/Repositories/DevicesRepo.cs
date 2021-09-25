using Gateways.Data.Repositories;
using Gateways.Exceptions;
using Gateways.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Gateways.Data
{
    public class DevicesRepo : BaseRepository, IDevicesRepo
    {
        private readonly GatewaysContext _context;

        public DevicesRepo(GatewaysContext context): base(context)
        {
            _context = context;
        }

        public List<Device> GetAllDevices() => _context.Devices.ToList();

        public Device GetDeviceById(long uid) 
        { 
            var device = _context.Devices.FirstOrDefault(g => g.UID == uid);
            if(device == null)
            {
                throw new DeviceNotExistisException(uid);
            }
            return device;
        }

        public void CreateDevice(Device device)
        {
            if(device != null)
            {
                _context.Devices.Add(device);
            }
        }
        public List<Device> GetDevicesPerGateway(string serialNumber) => _context.Devices.Where(d => d.SerialNumber == serialNumber).ToList();    

        public void AddDeviceOnGateway(string serialNumber, long uid) 
        {
            var gateway = _context.Gateways.FirstOrDefault(g => g.SerialNumber == serialNumber);
            if(gateway == null)
            {
                throw new GatewayNotExistisException(serialNumber);
            }

            var devices = _context.Devices.Where(d => d.SerialNumber == serialNumber);
            int numberOfDevices = devices.Count();
            if( numberOfDevices < 10)
            {
                var device = _context.Devices.FirstOrDefault(d => d.UID == uid);
                if(device == null) throw new DeviceNotExistisException(uid);
                
                if(device.SerialNumber == serialNumber)
                {
                    throw new DuplicateDeviceException(uid);
                }
                device.SerialNumber = serialNumber;                
            }
            else 
            {
                throw new MaximumAllowedDevicesException(serialNumber);
            }
        }
        public void RemoveDeviceFromGateway(string serialNumber, long uid)
        {
            var gateway = _context.Gateways.FirstOrDefault(g => g.SerialNumber == serialNumber);
            if(gateway == null)
            {
                throw new GatewayNotExistisException(serialNumber);
            }
            var device = _context.Devices.Where(d => d.SerialNumber == serialNumber).FirstOrDefault(d => d.UID == uid);

            if(device == null)
            {
                throw new DeviceNotExistisException(uid);
            }
            device.SerialNumber = null;                
        }
    }
}
