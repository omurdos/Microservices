using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using POSMS.DataSync.Grpc;
using POSMS.MessageBus;
using POSMS.Models;
using POSMS.Repositories;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<ApplicationDBContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("default")));
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<IDeviceMBClient, DeviceMBClient>();
builder.Services.AddGrpc();
var app = builder.Build();

//Seed the Database
DbInitializer.Initialize(app);

app.UseHttpLogging();
app.UseApiVersioning();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGrpcService<DeviceService>();

app.UseAuthorization();

app.MapControllers();

app.Run();

