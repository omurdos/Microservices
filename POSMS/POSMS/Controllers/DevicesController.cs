using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using POSMS.Dtos;
using POSMS.MessageBus;
using POSMS.Models;
using POSMS.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace POSMS.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DevicesController : ControllerBase
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DevicesController> _logger;
        private readonly IDeviceMBClient _mbclient;

        public DevicesController(IDeviceRepository deviceRepository, IMapper mapper, IDeviceMBClient mbclient, ILogger<DevicesController> logger)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
            _logger = logger;
            _mbclient = mbclient;
        }

        // GET: api/<DevicesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           
                var result = await _deviceRepository.GetAllDevicesAsync();
                var devices = _mapper.Map<List<DeviceDto>>(result);
                return Ok(devices);
           
        }

        // GET api/<DevicesController>/5
        [HttpGet("{id}", Name = "GetDeviceById")]
        public async Task<IActionResult> GetDeviceById(string id)
        {
            var device  = await _deviceRepository.GetDeviceByIdAsync(id);
            var dto = _mapper.Map<DeviceDto>(device);
            return Ok(dto);
        }

        // POST api/<DevicesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDeviceDto createDeviceDto)
        {
            if (ModelState.IsValid) {
                var device = _mapper.Map<Device>(createDeviceDto);
                device = await _deviceRepository.AddDeviceAsync(device);
                var dto = _mapper.Map<DeviceDto>(device);
                return CreatedAtRoute(nameof(GetDeviceById), new { id = dto.Id }, dto);
            }
            return BadRequest(createDeviceDto);
        }

        // PUT api/<DevicesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] UpdateDeviceDto updateDeviceDto)
        {
            if (ModelState.IsValid)
            {
                var device = await _deviceRepository.GetDeviceByIdAsync(id);
                if (device != null) {
                    _mapper.Map(updateDeviceDto, device);
                    var result = await _deviceRepository.UpdateDeviceAsync(device);

                    if (result && updateDeviceDto.SendToRepair) {
                        var deviceRepairDto = _mapper.Map<DeviceRepairDTO>(device);
                        deviceRepairDto.Event = "device_repair";
                        _mbclient.DeviceRepairUpdated(deviceRepairDto);
                    }

                    return result ? Ok(_mapper.Map<DeviceDto>(device)) : BadRequest(updateDeviceDto);
                }
                return NotFound();
            }
            return BadRequest(updateDeviceDto);
        }

        // DELETE api/<DevicesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var device = await _deviceRepository.GetDeviceByIdAsync(id);
            if (device != null)
            {
                var result = await _deviceRepository.DeleteDeviceAsync(device);
                return result ? NoContent() : BadRequest(); 
            }
            return NotFound();
        }
        
    }
}
