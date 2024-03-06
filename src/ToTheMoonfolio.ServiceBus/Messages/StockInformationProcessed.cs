namespace ToTheMoonfolio.ServiceBus.Messages;

public sealed record StockInformationProcessed(string Symbol, decimal Price);