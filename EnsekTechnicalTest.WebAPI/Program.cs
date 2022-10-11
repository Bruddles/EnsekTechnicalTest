using EnsekTechnicalTest.Database.Context;
using EnsekTechnicalTest.Database.Interfaces;
using EnsekTechnicalTest.Database.Repositories;
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
