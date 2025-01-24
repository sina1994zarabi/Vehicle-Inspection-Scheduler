using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Service;
using App.Domain.Service;
using App.Infra.Data.Ef;
using App.Infra.Data.Ef.Repositories;
using App.Services.AppService;
using App.Services.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var SaipaCap = builder.Configuration.GetSection("DailyCap:Saipa").Value;
var IranKhodroCap = builder.Configuration.GetSection("DailyCap:IranKhodro").Value;
builder.Services.AddSingleton(SaipaCap);
builder.Services.AddSingleton(IranKhodroCap);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IAppointmentAppService, AppointmentAppService>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IVehicleAppService, VehicleAppService>();
builder.Services.AddScoped<ICenterRepository, CenterRepository>();
builder.Services.AddScoped<ICenterService, CenterService>();
builder.Services.AddScoped<IOperatorRepository, OperatorRepository>();
builder.Services.AddScoped<IOperatorService, OperatorService>();
builder.Services.AddScoped<IOperatorAppService, OperatorAppService>();
builder.Services.AddScoped<IRejectedCarRepository, RejectedCarRepository>();
builder.Services.AddScoped<IRejectedCarService, RejectedCarService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
