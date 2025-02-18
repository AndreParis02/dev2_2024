using System.Globalization;
namespace _37_WebApp_SQLite.Utilities;
public static class PriceFormatter
{
    ///<summary>
    ///Formatta un valore double come valuta.
    ///</summary
    ///<param name="price">Il prezzo da formattare.</param>
    ///<returns>Una stringa formattata come valuta.</returns>
    public static string Format(double price)
    {
        //la localizzazione viene presa dal SO
        return price.ToString ("C",CultureInfo.CurrentCulture);
    }
}