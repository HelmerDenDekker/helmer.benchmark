using BenchmarkDotNet.Attributes;

namespace Helmer.Benchmark.Application;

public class DuplicateBenchMark
{
    private readonly List<DuplicateTest> _testList;

    public DuplicateBenchMark()
    {
        _testList = new();
        const int size = 10000;
        
        for (int i = 0; i < size; i++)
        {
            _testList.Add(new DuplicateTest
            {
                Id = i,
                Name = i.ToString()
            });
        }
        
        // change item 6666 to be duplicate
        _testList[6666].Name = _testList[1].Name;
    }


    [Benchmark(Baseline = true)]
    public void DuplicateForEach()
    {
        _testList.HasDuplicatesForEach();
    }

    [Benchmark]
    public void DuplicateGroupBy()
    {
        _testList.HasDuplicatesGroupBy();
    }

    [Benchmark]
    public void DuplicateHash()
    {
        _testList.HasDuplicatesHash();
    }

}