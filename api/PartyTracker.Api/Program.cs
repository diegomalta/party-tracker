using Amazon.DynamoDBv2;
using PartyTracker.Api.Repositories;
using PartyTracker.Api.Services;
using PartyTracker.Api.Settings;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();

// Add AWS Lambda support. When application is run in Lambda Kestrel is swapped out as the web server with Amazon.Lambda.AspNetCoreServer. This
// package will act as the webserver translating request and responses between the Lambda event source and ASP.NET Core.
builder.Services.AddAWSLambdaHosting(LambdaEventSource.RestApi);

builder.Services.Configure<DatabaseSettings>(config.GetSection(DatabaseSettings.KeyName));
builder.Services.AddAWSService<IAmazonDynamoDB>(config.GetAWSOptions());

builder.Services.AddSingleton<IEventRepository, EventRepository>();

builder.Services.AddSingleton<IEventService, EventService>();


var app = builder.Build();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => "Welcome to running ASP.NET Core Minimal API on AWS Lambda");

app.Run();
