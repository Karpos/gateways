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
    public class GatewaysController : ControllerBase
    {
        private readonly IGatewaysRepo _repository;
        private readonly IMapper _mapper;

        public GatewaysController(IGatewaysRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GatewayReadDto>> GetAllGateways()
        {
            var gatewayItems = _repository.GetAllGateways();            
            return Ok(_mapper.Map<List<GatewayReadDto>>(gatewayItems));
        }

        [HttpGet("{serialNumber}", Name = "GetGatewayBySerialNumber")]
        public ActionResult<GatewayReadDto> GetGatewayBySerialNumber(string serialNumber)
        {
            var gatewayItem = _repository.GetGatewayById(serialNumber);

            if(gatewayItem != null) 
            { 
                return Ok(_mapper.Map<GatewayReadDto>(gatewayItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<GatewayReadDto> CreateGateway(GatewayCreateDto gatewayCreateDto)
        {
            
            var gatewayModel = _mapper.Map<Gateway>(gatewayCreateDto);
            var gateway = _repository.GetGatewayById(gatewayModel.SerialNumber);
            if(gateway != null)
            {
                return ValidationProblem(ModelState);
            }
            try
            {
                _repository.CreateGateway(gatewayModel);
            }
            catch(DuplicateGatewayException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            _repository.SaveChanges();
            var grd = _mapper.Map<GatewayCreateDto>(gatewayModel);
            return CreatedAtRoute(nameof(GetGatewayBySerialNumber), new { SerialNumber = grd.SerialNumber }, grd);
        }
        
    }
}
