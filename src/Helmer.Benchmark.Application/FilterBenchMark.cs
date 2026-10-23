using BenchmarkDotNet.Attributes;
using Helmer.Benchmark.Application.Code;

namespace Helmer.Benchmark.Application;

public class FilterBenchMark
{
    private List<Filter> _filterSetOne;
    private List<Container> _containerSetOne;
    private readonly FilterService _filterService;

    public FilterBenchMark()
    {
        var firstFilterId = Guid.Parse("FDD50E45-DA5F-4463-BCF6-BF28E1213C6F");
        var secondFilterId = Guid.Parse("A1B2C3D4-E5F6-7890-1234-56789ABCDEF0");
        var containerOne = Guid.Parse("C1D2E3F4-5678-90AB-CDEF-1234567890AB");
        var containerTwo = Guid.Parse("D4E5F6A1-7890-1234-5678-90ABCDEF1234");
        var containerThree = Guid.Parse("E5F6A1B2-1234-5678-90AB-CDEF12345678");
        var containerFour = Guid.Parse("F6A1B2C3-5678-90AB-CDEF-1234567890AB");
        var containerFive = Guid.Parse("A1B2C3D4-90AB-CDEF-1234-567890ABCDEF");
        
        _filterSetOne = new List<Filter>
        {
            new() { FilterId = firstFilterId, Value = 70 },
            new() { FilterId = firstFilterId, Value = 140 },
            new() { FilterId = secondFilterId, Value = 200 },
        };
        _containerSetOne = new List<Container>
        {
            new()
            { 
                Name = "70x200",
                ContainerId = containerOne, 
                Properties = new List<Property>
                {
                    new() { FilterId = firstFilterId, Value = "70" },
                    new() { FilterId = secondFilterId, Value = "200" },
                },
            },
            new()
            { 
                Name = "140x200",
                ContainerId = containerTwo, 
                Properties = new List<Property>
                {
                    new() { FilterId = firstFilterId, Value = "140" },
                    new() { FilterId = secondFilterId, Value = "200" },
                },
            },
            new()
            { 
                Name = "70x210",
                ContainerId = containerThree, 
                Properties = new List<Property>
                {
                    new() { FilterId = firstFilterId, Value = "70" },
                    new() { FilterId = secondFilterId, Value = "210" },
                },
            },
            new()
            { 
                Name = "90x210",
                ContainerId = containerFour, 
                Properties = new List<Property>
                {
                    new() { FilterId = firstFilterId, Value = "90" },
                    new() { FilterId = secondFilterId, Value = "210" },
                },
            },
            new()
            { 
                Name = "90x200",
                ContainerId = containerFive, 
                Properties = new List<Property>
                {
                    new() { FilterId = firstFilterId, Value = "90" },
                    new() { FilterId = secondFilterId, Value = "200" },
                },
            }
        };
        _filterService = new FilterService();
    }


    [Benchmark]
    public void FilterContainersByGithubCopilot()
    {
        _filterService.FilterContainersByGithubCopilot(_containerSetOne, _filterSetOne);
    }
    
    [Benchmark]
    public void FilterContainersByGithubCopilotIterationTwo()
    {
        _filterService.FilterContainersByGithubCopilotIterationTwo(_containerSetOne, _filterSetOne);
    }

    [Benchmark(Baseline = true)]
    public void FilterContainersForEachByGroupReduceList()
    {
        _filterService.FilterContainersForEachByGroupReduceList(_containerSetOne, _filterSetOne);
    }

    [Benchmark]
    public void FilterContainersByMsCopilot()
    {
        _filterService.FilterContainersByMsCopilot(_containerSetOne, _filterSetOne);
    }
}