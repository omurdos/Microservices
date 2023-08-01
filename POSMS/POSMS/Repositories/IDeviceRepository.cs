using POSMS.Models;

namespace POSMS.Repositories
{
    public interface IDeviceRepository
    {
        public Task<IEnumerable<Device>> GetAllDevicesAsync();
        public Task<Device?> GetDeviceByIdAsync(string id);
        public Task<Device> AddDeviceAsync(Device device);
        public Task<bool> UpdateDeviceAsync(Device device);
        public Task<bool> DeleteDeviceAsync(Device device);
    }
}
