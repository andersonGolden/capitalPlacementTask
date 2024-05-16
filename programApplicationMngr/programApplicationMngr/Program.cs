using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection.Extensions;
using programApplicationMngr.Core.Repositories;
using programApplicationMngr.Core.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
builder.Services.AddSingleton((dbContext) =>
{
    //define cosmos db credentials
    var endpointUri = config["ComosDBSettings:EndpointUri"];
    var primaryKey = config["ComosDBSettings:PrimaryKey"];
    var dbName = config["ComosDBSettings:DBName"];

    //define comos client options
    var cosmosClientOptions = new CosmosClientOptions
    {
        ApplicationName = dbName,
    };

    var cosmosClient = new CosmosClient(endpointUri, primaryKey, cosmosClientOptions);
    return cosmosClient;
});
builder.Services.AddTransient<IProgramRepository, ProgramRepository>();
builder.Services.AddTransient<IQuestionTypeRepository, QuestionTypeRepository>();
builder.Services.AddTransient<IApplicationRepository, ApplicationRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
