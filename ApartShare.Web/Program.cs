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

app.UseExceptionHandler("/error");

app.UseMiddleware<CustomExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseRouting()
    .UseAuthentication()
    .UseAuthorization();


app.MapControllers();

app.Run();
