namespace GrupoA.Academic.Infra.Data.Generals;

public class AcademicDataType
{
    
    public static readonly string Integer = "integer";        
    public static readonly string Boolean = "boolean";
    public static readonly string Date = "timestamp with time zone";
    public static readonly string Uuid = "uuid";
    public static string String(int length = 255)
    {
        if (length <= 0)
            length = 255;

        return $"varchar({length})";
    }
    public static string DetaultNextval(string tableName, string propertyName = "Code")
    {
        return $"nextval('\"{SequenceName(tableName, propertyName)}\"')";
    }
    public static string SequenceName(string tableName, string propertyName = "Code")
    {
        return $"{tableName}_{propertyName}_seq";
    }
}