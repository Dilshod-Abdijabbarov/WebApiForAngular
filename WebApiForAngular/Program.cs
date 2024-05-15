using Microsoft.AspNetCore.RequestDecompression;
using Microsoft.EntityFrameworkCore;
using WebApiForAngular.Data;
using WebApiForAngular.Data.IRepositories;
using WebApiForAngular.Data.Repositories;
using WebApiForAngular.IServices;
using WebApiForAngular.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DotnetandAngularDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
builder.Services.AddScoped<IEmployeeService,EmployeeService>();
builder.Services.AddScoped<IDepartmentService,DepartmentService>();
builder.Services.AddScoped<ICarService,CarService>();



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
app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
