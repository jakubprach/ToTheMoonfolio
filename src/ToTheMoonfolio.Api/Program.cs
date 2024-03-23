using ToTheMoonfolio.Api;
using ToTheMoonfolio.Persistence;
using ToTheMoonfolio.ServiceBus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddPersistence(builder.Configuration);

var eventsToConsumers = new List<Type>
{
    typeof(StockInformationProcessedMessageHandler)
};

builder.Services.AddServiceBusWithConsumers(eventsToConsumers);

var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();