using BenchmarkDotNet.Attributes;
using Helmer.Benchmark.Application.Code;

namespace Helmer.Benchmark.Application
{
    public class SelectIdFromListBenchmark
    {
        [Benchmark(Baseline = true)]
        public void SelectFromList() => SelectFromListTest.TestEquals();
        
        [Benchmark]
        public void SelectFromListIs() => SelectFromListTest.TestIsIs();
        
        [Benchmark]
        public void SelectFromHashSet() => SelectFromListTest.TestHashSet();

        [Benchmark]
        public void SelectReverse() => SelectFromListTest.TestFilterOnStoreId();
        
        [Benchmark]
        public void SelectFromListIntersect() => SelectFromListTest.TestIntersect();
        
        [Benchmark]
        public void SelectFromListForeach() => SelectFromListTest.TestForeach();

    }
}
