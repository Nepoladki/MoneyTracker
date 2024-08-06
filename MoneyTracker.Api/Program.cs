using Microsoft.AspNetCore.CookiePolicy;
using MoneyTracker.Api;
using MoneyTracker.Application;
using MoneyTracker.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Adding folder for static files such as category icons
builder.Environment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

var config = builder.Configuration;

// Other layers DI
builder.Services.
    AddPresentation(config).
    AddApplication().
    AddInfrastructure(config);

var app = builder.Build();

app.UseStaticFiles();

app.UseExceptionHandler("/api/error");

app.UseCookiePolicy(new CookiePolicyOptions
{
    HttpOnly = HttpOnlyPolicy.Always,
    MinimumSameSitePolicy = SameSiteMode.Strict,
    Secure = CookieSecurePolicy.Always
 });

app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
