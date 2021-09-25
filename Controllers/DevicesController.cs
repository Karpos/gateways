using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Gateways.Data;
using Gateways.Dto;
using Gateways.Exceptions;
using Gateways.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gateways.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IDevicesRepo _repository;
        private readonly IMapper _mapper;

        public DevicesController(IDevicesRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DeviceReadDto>> GetAllDevices()
        {
            var deviceItems = _repository.GetAllDevices();            
            return Ok(_mapper.Map<List<DeviceReadDto>>(deviceItems));
        }

        [HttpGet("{uid}", Name = "GetDeviceByUid")]
        public ActionResult<DeviceReadDto> GetDeviceByUid(long uid)
        {
            try
            {
                var deviceItem = _repository.GetDeviceById(uid);
                return _mapper.Map<DeviceReadDto>(deviceItem);
            }
            catch(DeviceNotExistisException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult<DeviceReadDto> CreateDevice(DeviceCreateDto deviceCreateDto)
        {
            var deviceModel = _mapper.Map<Device>(deviceCreateDto);
            var device = _repository.GetDeviceById(deviceModel.UID);
            if(device != null)
            {
                return BadRequest("Record not created. UID number allredy exists");
            }
            _repository.CreateDevice(deviceModel);
            _repository.SaveChanges();
            var drd = _mapper.Map<DeviceReadDto>(deviceModel);
            return CreatedAtRoute(nameof(GetDeviceByUid), new { UID = drd.UID }, drd);
        }

         [HttpGet("gateway/{serialNumber}")]
        public ActionResult<List<DeviceReadDto>> GetDevicePerGateway(string serialNumber)
        {
            var devicesItems = _repository.GetDevicesPerGateway(serialNumber);
            if(devicesItems != null)
            {
                return Ok(_mapper.Map<List<DeviceReadDto>>(devicesItems));
            }
            return NotFound();
        }

        [HttpGet("gateway/{serialNumber}/{uid}")]
        public ActionResult<List<Device>> AddDeviceOnGateway(string serialNumber, long uid)
        {
            try
            {
                _repository.AddDeviceOnGateway(serialNumber, uid);
                _repository.SaveChanges();
                return Ok();
            }

            catch(DuplicateDeviceException ex)
            {
                return Conflict(new { message = ex.Message });
            }  
            catch(DeviceNotExistisException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch(GatewayNotExistisException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch(MaximumAllowedDevicesException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            
        }

        [HttpDelete("gateway/{serialNumber}/{uid}")]
        public ActionResult<List<Device>> RemoveDeviceFromGateway(string serialNumber, long uid)
        {
            try
            {
                _repository.RemoveDeviceFromGateway(serialNumber, uid);
                _repository.SaveChanges();
                return Ok();
            }
            catch(GatewayNotExistisException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch(DeviceNotExistisException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
