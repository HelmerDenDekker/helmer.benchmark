using BenchmarkDotNet.Attributes;
using Helmer.Benchmark.Application.Code;

namespace Helmer.Benchmark.Application
{
    public class CountVersusAnyBenchmark
    {
    	[Benchmark]
    	public bool IEnumerableWithCountParenthesis() => CountVersusAnyTest.TestIEnumerableWithCountParenthesis();

    	[Benchmark]
    	public bool IEnumerableWithToListAndCount() => CountVersusAnyTest.TestIEnumerableWithToListAndCount();

    	[Benchmark(Baseline = true)]
    	public bool IEnumerableWithAny() => CountVersusAnyTest.TestIEnumerableWithAny();

    	[Benchmark]
    	public bool ReadOnlyCollectionWithCountParenthesis() => CountVersusAnyTest.TestReadOnlyCollectionWithCountParenthesis();

    	[Benchmark]
    	public bool ReadOnlyCollectionWithCount() => CountVersusAnyTest.TestReadOnlyCollectionWithCount();

    	[Benchmark]
    	public bool ReadOnlyCollectionWithAny() => CountVersusAnyTest.TestReadOnlyCollectionWithAny();

    	[Benchmark]
    	public bool NullableReadOnlyCollectionWithCount() => CountVersusAnyTest.TestNullableReadOnlyCollectionWithCount();

    	[Benchmark]
    	public bool NullReadOnlyCollectionWithCount() => CountVersusAnyTest.TestNullReadOnlyCollectionWithCount();
    }
}
