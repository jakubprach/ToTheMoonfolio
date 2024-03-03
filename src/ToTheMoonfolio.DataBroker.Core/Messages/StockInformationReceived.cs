namespace ToTheMoonfolio.DataBroker.Core.Messages;

public sealed record StockInformationReceived(string Symbol, decimal Price);