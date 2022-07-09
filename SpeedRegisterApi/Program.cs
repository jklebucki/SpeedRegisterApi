using Microsoft.EntityFrameworkCore;
using SpeedRegisterApi.Data;
using SpeedRegisterApi.Repositories;
using SpeedRegisterApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<InterlanDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("MsSqlConnectionTest")));
builder.Services.AddTransient<ITaborRepository, TaborRepository>();
builder.Services.AddTransient<ITerminarzRepository, TerminarzRepository>();
builder.Services.AddTransient<ITerminarzService, TerminarzService>();
builder.Services.AddTransient<ITaborService, TaborService>();

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
