using System;
using System.Net.NetworkInformation;
using GoogleMapInfo;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
  {
      c.SwaggerDoc("v1", new OpenApiInfo { Title = "My map API", Version = "v1" });
  }); 
builder.Services.AddTransient<GoogleDistanceApi>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwagger(c =>
    //{
    //    c.SwaggerEndpoint("/swagger/v1/swagger.json","My microservice for map information.");
    //});
    app.UseSwaggerUI(c=>c.SwaggerEndpoint("/swagger/v1/swagger.json\",\"My microservice for map information."));
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

