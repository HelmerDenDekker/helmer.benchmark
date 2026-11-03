namespace Helmer.Benchmark.Application.Code;

public static class TagNameComparisonExtensions
{
    private static string _compareTag = "li";
    
    public static bool TagEquals(this string input)
    {
        return input == _compareTag;
    }
    
    public static bool TagEqualsOrdinalIgnore(this string input)
    {
        return string.Equals(input, _compareTag, StringComparison.OrdinalIgnoreCase);
    }
    
    public static bool TagEqualsInvarianCulture(this string input)
    {
        return string.Equals(input, _compareTag, StringComparison.InvariantCultureIgnoreCase);
    }
}