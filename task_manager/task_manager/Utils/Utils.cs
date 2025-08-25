using System;
using System.Globalization;

public static class Utils
{
    private static readonly string[] DateFormats = {
        "dd/MM/yyyy",
        "yyyy/MM/dd",
        "dd-MM-yyyy",
        "yyyy-MM-dd",
        "ddMMyyyy",
        "yyyyMMdd"
    };
    
    public static string ToFormattedDate(string date)
    {
        if (string.IsNullOrWhiteSpace(date))
        {
            throw new ArgumentNullException(nameof(date), "A data não pode ser nula ou vazia.");
        }
    
        bool success = DateTime.TryParseExact(
            date,
            DateFormats, 
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out DateTime parsedDate
        );
    
        if (success)
        {
            return parsedDate.ToString("yyyy-MM-dd");
        }
        else
        {
            throw new FormatException($"A data '{date}' está em um formato inválido ou não é suportado.");
        }
    }
}
