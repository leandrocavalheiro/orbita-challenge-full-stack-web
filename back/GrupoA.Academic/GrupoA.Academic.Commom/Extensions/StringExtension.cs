using System.Globalization;

namespace GrupoA.Academic.Commom.Extensions;
public static class StringExtension
{
    public static string PascalCase(this string value)
    {
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
    }
}