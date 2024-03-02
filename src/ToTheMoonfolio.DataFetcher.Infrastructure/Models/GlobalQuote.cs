﻿using System.Text.Json.Serialization;

public class GlobalQuoteResponse
{
    [JsonPropertyName("Global Quote")]
    public GlobalQuote GlobalQuote { get; set; }
}

public class GlobalQuote
{
    [JsonPropertyName("01. symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("02. open")]
    public string Open { get; set; }

    [JsonPropertyName("03. high")]
    public string High { get; set; }

    [JsonPropertyName("04. low")]
    public string Low { get; set; }

    [JsonPropertyName("05. price")]
    public string Price { get; set; }

    [JsonPropertyName("06. volume")]
    public string Volume { get; set; }

    [JsonPropertyName("07. latest trading day")]
    public string LatestTradingDay { get; set; }

    [JsonPropertyName("08. previous close")]
    public string PreviousClose { get; set; }

    [JsonPropertyName("09. change")]
    public string Change { get; set; }

    [JsonPropertyName("10. change percent")]
    public string ChangePercent { get; set; }
}