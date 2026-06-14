using Application.Helpers;
using Application.Intrerfaces;
using Application.Services;
using AutoMapper;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;
using System.Text.Json.Serialization;
using WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);
//Create Logger from settings from appsettings.json
var logger = new LoggerConfiguration()
.ReadFrom.Configuration(builder.Configuration)
.CreateLogger();
//Add Logger
Log.Logger = logger;
builder.Host.UseSerilog(logger);
//Connect to Sql Server Database

var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connections String Default Connectionstring Not Found");
builder.Services.AddDbContext<AppDbContext>(Options => Options
.UseLazyLoadingProxies(true)
.UseSqlServer(connectionstring));
//Add Data Related Service
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped<IDataService, DataService>();

//Add AutoMapper
var mapperConfig = new MapperConfiguration(o => o.AddProfile(new AutoMapperProfile()));
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
//Add Controller
builder.Services.AddControllers().AddJsonOptions(o => o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<CustomExceptionMiddleWare>();
//Use Serilog
app.UseSerilogRequestLogging();
app.UseAuthorization();

app.MapControllers();

app.Run();
