using FonTech.Api;
using FonTech.Api.Middlewares;
using FonTech.Application.DependencyInjection;
using FonTech.Consumer.DependencyInjection;
using FonTech.DAL.DependencyInjection;
using FonTech.Domain.Settings;
using FonTech.Producer.DependencyInjection;
using Prometheus;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RabbitMqSettings>(builder.Configuration.GetSection(nameof(RabbitMqSettings)));
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.DefaultSection));
builder.Services.Configure<RedisSettings>(builder.Configuration.GetSection(nameof(RedisSettings)));

builder.Services.AddEndpointsApiExplorer();
builder.Services.UseHttpClientMetrics();

builder.Services.AddControllers();

builder.Services.AddAuthenticationAndAuthorization(builder);
builder.Services.AddSwagger();

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddDataAccessLayer(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddProducer();
builder.Services.AddConsumer();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "FonTech Swagger v1.0");
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "FonTech Swagger v2.0");
        c.RoutePrefix = string.Empty;
    });
}

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseMetricServer();
app.UseHttpMetrics();

app.MapGet("/random-number", () =>
{
    var number = Random.Shared.Next(0, 10);
    return Results.Ok(number);
});

app.MapMetrics();
app.MapControllers();

app.Run();