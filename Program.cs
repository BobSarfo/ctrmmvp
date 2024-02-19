using ctrmmvp.DTOs;
using ctrmmvp.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IServiceCollection services = builder.Services;
var dbUrl = builder.Configuration.GetConnectionString("default");

services.AddControllers();

services.AddEndpointsApiExplorer();
services.AddCors();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.WriteIndented = true;
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
}).ConfigureApiBehaviorOptions(options =>
{
    //add custom error response
    options.InvalidModelStateResponseFactory = context => new BadRequestObjectResult(
        new BadRequestApiResponse("validation errors")
        {
            Errors = context.GetError()
        });
});

services.AddCTRMSwagger();
services.AddDb(dbUrl);
services.AddBeans();
services.AddAppSettingsBeans(builder.Configuration);
services.AddAuth(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Services.RunMigrations().GetAwaiter().GetResult();

app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();