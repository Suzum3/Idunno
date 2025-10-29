namespace FuckingCalculator.Extensions;

public static class StringExtensions
{
    public static bool StartsWithAny(this string @string, params string[] values)
    {
        return values.Any(@string.StartsWith);
    }

    public static bool EndsWithAny(this string @string, params string[] values)
    {
        return values.Any(@string.EndsWith);
    }
}