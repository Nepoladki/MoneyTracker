using MoneyTracker.Api;
using MoneyTracker.Application;
using MoneyTracker.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

builder.Services.
    AddPresentation().
    AddApplication().
    AddInfrastructure(config);

var app = builder.Build();

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run(); 
