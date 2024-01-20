using Microsoft.EntityFrameworkCore;
using SmartMonitoringSystem.Interface;
using SmartMonitoringSystem.Models;
using SmartMonitoringSystem.Repositories;
using SmartMonitoringSystem.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(
          options =>
          {
              options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
          }); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<FypContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("fyp")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<ITargetRepository, TargetRepository>();
builder.Services.AddScoped<INationalityRepository, NationalityRepository>();
builder.Services.AddScoped<IGenderRepository, GenderRepository>();
builder.Services.AddScoped<IFamilyStatusRepository, FamilyStatusRepository>();
builder.Services.AddScoped<IAlertRepository, AlertRepository>();
builder.Services.AddScoped<ICameraRepository, CameraRepository>();
builder.Services.AddScoped<ISuspectRepository, SuspectRepository>();
builder.Services.AddScoped<IPhotoRepository, PhotoRepository>();
builder.Services.AddScoped<IWarrantRepository, WarrantRepository>();
builder.Services.AddScoped<IWarrantStatusRepository, WarrantStatusRepository>();
builder.Services.AddScoped<IKeywordRepository, KeywordRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ITargetStatusRepository, TargetStatusRepository>();
builder.Services.AddSingleton<FileService>();
builder.Services.AddSingleton<FileService>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();

