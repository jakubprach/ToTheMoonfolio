namespace ToTheMoonfolio.ServiceBus.Messages;

public sealed record StockInformationReceived(string Symbol, decimal Price);