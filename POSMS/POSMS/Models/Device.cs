namespace POSMS.Models
{
    public class Device : BaseEntity
    {
        public string Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string IMEI { get; set; }
        public bool SendToRepair { get; set; }
    }
}
