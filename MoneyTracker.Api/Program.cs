using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MoneyTracker.Api;
using MoneyTracker.Application;
using MoneyTracker.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

// Swagger setup
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            },
            Array.Empty<string>()
        }
    });
});

// CORS setup
builder.Services.AddCors(options =>
{
    options.AddPolicy("defaultPolicy", policyBuilder =>
    {
        policyBuilder.WithOrigins(builder.Configuration.GetSection("CorsOptions:Origins").Get<string[]>());
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowCredentials();
    });
});


// Other DI
builder.Services.
    AddPresentation().
    AddApplication().
    AddInfrastructure(config);

var app = builder.Build();

app.UseExceptionHandler("/error");

app.UseCookiePolicy(new CookiePolicyOptions
{
    HttpOnly = HttpOnlyPolicy.Always,
    MinimumSameSitePolicy = SameSiteMode.Strict,
    Secure = CookieSecurePolicy.Always
 });

app.UseCors("defaultPolicy");

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
