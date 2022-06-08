using Common.Models;
using Core.Interface;
using Core.Implementation;
using Data;
using Microsoft.EntityFrameworkCore;
using Data.Repositories.Interfaces;
using Data.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DemoAPIContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<IManager<Dept>, DeptMaster>();
builder.Services.AddTransient<IManager<Emp>, EmpMaster>();

builder.Services.AddTransient<IWebHelper, WebHelper>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient(typeof(IRepository<>), typeof(EfRepository<>));


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
