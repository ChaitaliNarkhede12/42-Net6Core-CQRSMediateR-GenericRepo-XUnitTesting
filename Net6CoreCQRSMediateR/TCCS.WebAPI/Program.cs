using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TCCS.DataAccess;
using TCCS.DataAccess.Models;
using TCCS.CQRSMediator;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddDbContext<TccsContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("TccsConn")));

builder.Services.ConfigureCQRSCommands(builder.Configuration);

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();


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

app.UseAuthorization();

app.MapControllers();

app.Run();
