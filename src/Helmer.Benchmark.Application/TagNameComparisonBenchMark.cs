using BenchmarkDotNet.Attributes;
using Helmer.Benchmark.Application.Code;

namespace Helmer.Benchmark.Application;

public class TagNameComparisonBenchMark
{
    private readonly string _testTagName = "li";
 
    [Benchmark(Baseline = true)]
    public void TagNameCompareOrdinal()
    {
        var result = _testTagName.TagEqualsOrdinalIgnore();
    }

    [Benchmark]
    public void TagNameCompareEqualsSign()
    {
        var result = _testTagName.TagEquals();
    }

    [Benchmark]
    public void TagNameCompareEqualsInvariant()
    {
        var result = _testTagName.TagEqualsInvarianCulture();
    }
}