using POSMS.Dtos;

namespace POSMS.MessageBus
{
    public interface IDeviceMBClient : IDisposable
    {
        void DeviceRepairUpdated(DeviceRepairDTO dto);

    }
}
