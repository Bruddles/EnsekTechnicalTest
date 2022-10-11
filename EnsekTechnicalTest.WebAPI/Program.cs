using CsvHelper;
using EnsekTechnicalTest.Database.Context;
using EnsekTechnicalTest.Database.Interfaces;
using EnsekTechnicalTest.Database.Repositories;
using EnsekTechnicalTest.Models;
using EnsekTechnicalTest.Models.Database;
using EnsekTechnicalTest.Services.Services;
using EnsekTechnicalTest.Services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DBConnection");
connectionString = "server=(localdb)\\MSSQLLocalDB;database=EnsekDb;Trusted_Connection=true";
builder.Services.AddDbContext<EnsekContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IMeterReadingRepository, MeterReadingRepository>();
builder.Services.AddTransient<IMeterReadingService, MeterReadingService>();
builder.Services.AddTransient<ICsvParser<MeterReadingFromFile>, CsvParser<MeterReadingFromFile>>();
builder.Services.AddTransient<ICsvParser<MeterReading>, CsvParser<MeterReading>>();

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
