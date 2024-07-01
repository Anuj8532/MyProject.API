using MyProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using MyProject.Domain.Interface;
using MyProject.Infrastructure.Repositery;
using MyProject.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<EmployeeDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDBContext") ?? throw new InvalidOperationException("Connection string 'EmployeeDbContext' not found.")));

var SQL_IP = Environment.GetEnvironmentVariable("SQL_IP");
var SQL_DB = Environment.GetEnvironmentVariable("SQL_DB");
var SQL_Conn_STRING = $"Server={SQL_IP};Database={SQL_DB};Trusted_Connection = True; Encrypt=False; MultipleActiveResultSets=True";

builder.Services.AddDbContext<EmployeeDbContext>(options =>
{
    options.UseSqlServer(SQL_Conn_STRING);
});

builder.Services.AddTransient<IEmployeeRepo, EmployeeRepo>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();

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
