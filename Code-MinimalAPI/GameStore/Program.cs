using GameStore.Auth;
using GameStore.Data;
using GameStore.Endpoints;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// start service registration
builder.Services.AddAuthentication(ApiKeySchemeConstant.SchemeName)
    .AddScheme<ApiKeyAuthSchemeOptions, ApiKeyAuthHandler>(ApiKeySchemeConstant.SchemeName, _ => { });
builder.Services.AddAuthorization();

builder.Services.AddSingleton<IDbConnectionFactory>(new SqliteConnectionFactory(builder.Configuration.GetValue<string>("Database:ConnectionString")));
builder.Services.AddSingleton<DatabaseInitializer>();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddGameEndpoint();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

//use endpoints
app.UseGameEndpoints();

//init database
var databaseInitializer = app.Services.GetRequiredService<DatabaseInitializer>();
await databaseInitializer.InitializeAsync();

app.Run();



