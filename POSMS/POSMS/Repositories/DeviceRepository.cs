using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using POSMS.Models;

namespace POSMS.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly ApplicationDBContext _context;

        public DeviceRepository(ApplicationDBContext context)
        {
               _context = context;
        }
        public async Task<Device> AddDeviceAsync(Device device)
        {
            await _context.Devices.AddAsync(device);
            await _context.SaveChangesAsync();
            return device;
        }

        public async Task<bool> DeleteDeviceAsync(Device device)
        {
            _context.Devices.Remove(device);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Device>> GetAllDevicesAsync()
        {
            return await _context.Devices.ToListAsync();
        }

        public async Task<Device> GetDeviceByIdAsync(string id)
        {
            var device = await _context.Devices.FindAsync(id);
            return device;
        }

        public async Task<bool> UpdateDeviceAsync(Device device)
        {
            _context.Devices.Update(device);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

    }
}
