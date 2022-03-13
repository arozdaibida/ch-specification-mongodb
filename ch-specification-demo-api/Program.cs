using ch_specification_demo_api;
using ch_specification_demo_api.Infrastructure.Factories;
using ch_specification_demo_api.Infrastructure.Repository;
using ch_specification_demo_api.Settings;
using FastEndpoints;
using FastEndpoints.Swagger;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbSettings>(options 
    => builder.Configuration.GetSection(Constants.Settings.BeerStoreDatabase).Bind(options));

builder.Services.AddFastEndpoints();
builder.Services.AddMediatR(typeof(Program).Assembly);

builder.Services
    .AddTransient<IMongoClientFactory, MongoClientFactory>()
    .AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));

builder.Services.AddSwaggerDoc();

var app = builder.Build();

app.UseAuthorization();
app.UseFastEndpoints();
app.UseOpenApi();
app.UseSwaggerUi3(c => c.ConfigureDefaults());

app.Run();
