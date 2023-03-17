using ApartShare.Application;
using ApartShare.Infrastructure;
using ApartShare.Web;
using ApartShare.Web.Middleware;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services
    .AddWeb(configuration)
    .AddApplication()
    .AddInfrastructure(configuration);

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication()
    .UseRouting()
    .UseAuthorization();

app.UseMiddleware<ValidationExceptionMiddleware>();

app.MapControllers();

app.Run();
