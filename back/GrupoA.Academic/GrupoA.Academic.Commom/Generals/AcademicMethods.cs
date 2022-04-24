using GrupoA.Academic.Commom.Extensions;

namespace GrupoA.Academic.Commom.Generals;

public static class AcademicMethods
{
    public static DateTime Now()
    {
        return DateTime.UtcNow.SetKind();
    }
}