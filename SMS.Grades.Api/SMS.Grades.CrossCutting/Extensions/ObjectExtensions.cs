namespace SMS.Grades.CrossCutting.Extensions;

public static class ObjectExtensions
{
    public static bool IsNull(this object? source)
        => source is null;
}