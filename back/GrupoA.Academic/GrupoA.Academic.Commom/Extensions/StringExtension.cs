using System.Globalization;

namespace GrupoA.Academic.Commom.Extensions;
public static class StringExtension
{
    public static string PascalCase(this string value)    
        => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);

    public static string RemoveCpfMask(this string value)
        => value.Replace(".", "")
                .Replace("-", "");

}