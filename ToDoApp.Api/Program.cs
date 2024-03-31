using Microsoft.Extensions.Configuration;
using ToDoApp.Application;
using ToDoApp.Domain.Contracts.Repositories;
using ToDoApp.Infrastructure;
using ToDoApp.Persistence;
using ToDoApp.Persistence.DatabaseContext;
using ToDoApp.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();


builder.Services.AddCors(options =>
{
	options.AddPolicy("all", builder => builder.AllowAnyOrigin()
											  .AllowAnyHeader()
											  .AllowAnyMethod());
});

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
