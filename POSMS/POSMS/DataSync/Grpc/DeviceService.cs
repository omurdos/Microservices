using AutoMapper;
using Grpc.Core;
using GrpcService;
using POSMS.Repositories;
using static GrpcService.DeviceService;

namespace POSMS.DataSync.Grpc
{
    public class DeviceService : DeviceServiceBase
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;

        public DeviceService(IDeviceRepository deviceRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
        }
        public override async Task<DeviceResponse> GetDeviceDetails(DeviceRequest request, ServerCallContext context)
        {
            //This is async method
            var device = await _deviceRepository.GetDeviceByIdAsync(request.Id);
            var grpcDevice = new GrpcDevice();
            _mapper.Map(device, grpcDevice);
            return new DeviceResponse { Device = grpcDevice };

        }
    }
}
