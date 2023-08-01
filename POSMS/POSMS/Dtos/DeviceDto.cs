using System.ComponentModel.DataAnnotations;

namespace POSMS.Dtos
{
    public class DeviceDto
    {
        public string Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string IMEI { get; set; }
        public bool SendToRepair { get; set; }

    }
    public class CreateDeviceDto
    {
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        [Required]
        public string IMEI { get; set; }
        public bool SendToRepair { get; set; }

    }
    public class UpdateDeviceDto
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; } 
        public string SerialNumber { get; set; }
        public string IMEI { get; set; }
        public bool SendToRepair { get; set; }

    }
}
