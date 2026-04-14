using BenchmarkDotNet.Attributes;

namespace Helmer.Benchmark.Application;

public class DuplicatesBenchMark
{
    private readonly List<DuplicateTest> _testList;

    public DuplicatesBenchMark()
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
    public void DuplicateHashSet()
    {
        var duplicates = _testList.GetDuplicatesHashSet();
        Console.WriteLine("The duplicate elements in the list are: " + string.Join(", ", duplicates));
    }

    [Benchmark]
    public void DuplicateGroupBy()
    {
        var duplicates = _testList.GetDuplicatesGroupBy();
        Console.WriteLine("The duplicate elements in the list are: " + string.Join(", ", duplicates));
    }

    [Benchmark]
    public void DuplicateDictionary()
    {
        var duplicates = _testList.GetDuplicatesDictionary();
        Console.WriteLine("The duplicate elements in the list are: " + string.Join(", ", duplicates));
    }
    
    [Benchmark]
    public void DuplicateFindAll()
    {
        var duplicates = _testList.GetDuplicatesFindAll();
        Console.WriteLine("The duplicate elements in the list are: " + string.Join(", ", duplicates));
    }
    
    [Benchmark]
    public void DuplicateContains()
    {
        var duplicates = _testList.GetDuplicatesContains();
        Console.WriteLine("The duplicate elements in the list are: " + string.Join(", ", duplicates));
    }

}