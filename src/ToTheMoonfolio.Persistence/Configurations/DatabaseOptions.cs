namespace ToTheMoonfolio.Persistence.Configurations;

public class DatabaseOptions
{
    public string ConnectionString { get; set; }
    public int CommandTimeout { get; set; }
    public bool EnableDetailedErrors { get; set; }
}