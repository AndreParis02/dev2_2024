using Azure;

public static class DbInitializer
{
    public static void Initialize(RequestContext context)
    {
        var tipi = new Tipo[]
        {
            new Tipo{Nome="Carta_Identita"},
            new Tipo{Nome="Patente"},
            new Tipo{Nome="Passaporto"}
        };
    }
}
