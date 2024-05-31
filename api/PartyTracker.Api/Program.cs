using Amazon.DynamoDBv2;
using FluentValidation;
using FluentValidation.AspNetCore;
using PartyTracker.Api.Middleware;
using PartyTracker.Api.Repositories;
using PartyTracker.Api.Services;
using PartyTracker.Api.Settings;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("default", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.Configure<DatabaseSettings>(config.GetSection(DatabaseSettings.KeyName));
builder.Services.AddAWSService<IAmazonDynamoDB>(config.GetAWSOptions());

builder.Services.AddSingleton<IEventRepository, EventRepository>();
builder.Services.AddSingleton<IGuestRepository, GuestRepository>();

builder.Services.AddSingleton<IEventService, EventService>();
builder.Services.AddSingleton<IGuestService, GuestService>();

// Add AWS Lambda support. When application is run in Lambda Kestrel is swapped out as the web server with Amazon.Lambda.AspNetCoreServer. This
// package will act as the webserver translating request and responses between the Lambda event source and ASP.NET Core.
builder.Services.AddAWSLambdaHosting(LambdaEventSource.RestApi);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("default");
app.UseAuthorization();
app.UseMiddleware<LoggerMiddleware>();
app.MapControllers();

app.MapGet("/", () => "Welcome to running ASP.NET Core Minimal API on AWS Lambda");

app.Run();
