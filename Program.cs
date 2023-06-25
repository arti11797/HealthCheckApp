using HealthCheckApp;
//using HealthCheckDemo;
using HealthChecks.UI.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient();
builder.Services.AddControllers();

builder.Services
    .AddHealthChecks()
    .AddCheck<CustomHealthCheck>(nameof(CustomHealthCheck))
    .AddCheck<ApiHealthCheck>(nameof(ApiHealthCheck))
    .AddCheck<DbHealthCheck>(nameof(DbHealthCheck));

builder.Services
    .AddHealthChecksUI(options =>
    {
        options.AddHealthCheckEndpoint("Healthcheck API", "/healthcheck");
    })
    .AddInMemoryStorage();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapHealthChecks("/healthcheck", new()
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.MapHealthChecksUI(options => options.UIPath = "/dashboard");
app.Run();