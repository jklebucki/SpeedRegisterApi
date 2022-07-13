using Microsoft.EntityFrameworkCore;
using SpeedRegisterApi.Data;
using SpeedRegisterApi.Repositories;
using SpeedRegisterApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<InterlanDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("MsSqlConnection")));
builder.Services.AddTransient<IFleetRepository, FleetRepository>();
builder.Services.AddTransient<IScheduleRepository, ScheduleRepository>();
builder.Services.AddTransient<IScheduleService, ScheduleService>();
builder.Services.AddTransient<IFleetService, FleetService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
builder.WebHost.UseUrls("http://*:8080");
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("corsapp");
app.UseAuthorization();

app.MapControllers();

app.Run();
