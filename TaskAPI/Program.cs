using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskAPI.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TaskAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TaskAPIContext") ?? throw new InvalidOperationException("Connection string 'TaskAPIContext' not found.")));

builder.Services.AddCors(options => options.AddPolicy(name: "EmployeeOrigins", policy =>
{
  policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
}));
// Add services to the container.

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
app.UseCors("EmployeeOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
