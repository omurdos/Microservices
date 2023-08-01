using Microsoft.EntityFrameworkCore;

namespace POSMS.Models
{
    public class DbInitializer
    {
        public static void Initialize(IApplicationBuilder app)
        {

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationDBContext>();
                    context.Database.Migrate();
                    context.Database.EnsureCreated();
                    if (!context.Devices.Any())
                    {
                        var devices = new List<Device>
            {
                new Device { Id = "1",Manufacturer = "Xaiomi", Model = "Sunmi V1" ,SerialNumber = "1",IMEI = "1234567", },
                new Device { Id = "2",Manufacturer = "Xaiomi", Model = "Sunmi V1" ,SerialNumber = "2",IMEI = "1234568", },
                new Device {Id = "3", Manufacturer = "Xaiomi", Model = "Sunmi V1" ,SerialNumber = "3",IMEI = "1234569", },
                new Device { Id = "4",Manufacturer = "Xaiomi", Model = "Sunmi V1" ,SerialNumber = "4",IMEI = "12345610", },

            };

                        context.Devices.AddRange(devices);
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }


        }
    }
}
