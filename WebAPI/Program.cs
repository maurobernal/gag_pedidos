//user: joaquin
//password: joaquin1
using WebAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;
using WebAPI.Services;
using WebAPI.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDBContext>(o => o.UseSqlServer("Data Source=172.0.0.15;Initial Catalog=EF2;User=joaquin;password=joaquin1"));
builder.Services.AddTransient<IOrigenService, OrigenService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
