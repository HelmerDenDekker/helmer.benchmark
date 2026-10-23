using FluentAssertions;
using Helmer.Benchmark.Application.Code;

namespace Helmer.Benchmark.Application.Tests;

public class FilterServiceUnitTests
{
    private Guid _firstFilterId;
    private Guid _secondFilterId;
    private List<Filter> _filterSetOne;
    private Guid _containerOne;
    private Guid _containerTwo;
    private Guid _containerThree;
    private List<Container> _containerSetOne;
    private Guid _containerFour;
    private Guid _containerFive;

    [SetUp]
    public void Setup()
    {
        _firstFilterId = Guid.Parse("FDD50E45-DA5F-4463-BCF6-BF28E1213C6F");
        _secondFilterId = Guid.Parse("A1B2C3D4-E5F6-7890-1234-56789ABCDEF0");
        _containerOne = Guid.Parse("C1D2E3F4-5678-90AB-CDEF-1234567890AB");
        _containerTwo = Guid.Parse("D4E5F6A1-7890-1234-5678-90ABCDEF1234");
        _containerThree = Guid.Parse("E5F6A1B2-1234-5678-90AB-CDEF12345678");
        _containerFour = Guid.Parse("F6A1B2C3-5678-90AB-CDEF-1234567890AB");
        _containerFive = Guid.Parse("A1B2C3D4-90AB-CDEF-1234-567890ABCDEF");
        
        _filterSetOne = new List<Filter>
        {
            new() { FilterId = _firstFilterId, Value = 70 },
            new() { FilterId = _firstFilterId, Value = 140 },
            new() { FilterId = _secondFilterId, Value = 200 },
        };
        _containerSetOne = new List<Container>
        {
            new()
            { 
                Name = "70x200",
                ContainerId = _containerOne, 
                Properties = new List<Property>
                {
                    new() { FilterId = _firstFilterId, Value = "70" },
                    new() { FilterId = _secondFilterId, Value = "200" },
                },
            },
            new()
            { 
                Name = "140x200",
                ContainerId = _containerTwo, 
                Properties = new List<Property>
                {
                    new() { FilterId = _firstFilterId, Value = "140" },
                    new() { FilterId = _secondFilterId, Value = "200" },
                },
            },
            new()
            { 
                Name = "70x210",
                ContainerId = _containerThree, 
                Properties = new List<Property>
                {
                    new() { FilterId = _firstFilterId, Value = "70" },
                    new() { FilterId = _secondFilterId, Value = "210" },
                },
            },
            new()
            { 
                Name = "90x210",
                ContainerId = _containerFour, 
                Properties = new List<Property>
                {
                    new() { FilterId = _firstFilterId, Value = "90" },
                    new() { FilterId = _secondFilterId, Value = "210" },
                },
            },
            new()
            { 
                Name = "90x200",
                ContainerId = _containerFive, 
                Properties = new List<Property>
                {
                    new() { FilterId = _firstFilterId, Value = "90" },
                    new() { FilterId = _secondFilterId, Value = "200" },
                },
            }
        };

    }
    
    [Test]
    public void FilterContainersForEachByGroupReduceList()
    {
        // Arrange
        var filterService = new FilterService();
        
        // Act
        var filteredContainers = filterService.FilterContainersForEachByGroupReduceList(_containerSetOne, _filterSetOne);
        
        // Assert
        filteredContainers.Should().HaveCount(2);
        filteredContainers.Should().ContainSingle(c => c.ContainerId == _containerOne);
        filteredContainers.Should().ContainSingle(c => c.ContainerId == _containerTwo);
    }
    
    // [Test]
    // public void FilterContainersWithUniqueFilters()
    // {
    //     // Arrange
    //     var filterService = new FilterService();
    //     
    //     // Act
    //     var filteredContainers = filterService.FilterContainersWithUniqueFilters(_containerSetOne, _filterSetOne);
    //     
    //     // Assert
    //     filteredContainers.Should().HaveCount(2);
    //     filteredContainers.Should().ContainSingle(c => c.ContainerId == _containerOne);
    //     filteredContainers.Should().ContainSingle(c => c.ContainerId == _containerTwo);
    // }
    
    [Test]
    public void FilterContainersByGithubCopilot()
    {
        // Arrange
        var filterService = new FilterService();
        
        // Act
        var filteredContainers = filterService.FilterContainersByGithubCopilot(_containerSetOne, _filterSetOne);
        
        // Assert
        filteredContainers.Should().HaveCount(2);
        filteredContainers.Should().ContainSingle(c => c.ContainerId == _containerOne);
        filteredContainers.Should().ContainSingle(c => c.ContainerId == _containerTwo);
    }
    
    [Test]
    public void FilterContainersByMsCopilot()
    {
        // Arrange
        var filterService = new FilterService();
        
        // Act
        var filteredContainers = filterService.FilterContainersByMsCopilot(_containerSetOne, _filterSetOne);
        
        // Assert
        filteredContainers.Should().HaveCount(2);
        filteredContainers.Should().ContainSingle(c => c.ContainerId == _containerOne);
        filteredContainers.Should().ContainSingle(c => c.ContainerId == _containerTwo);
    }
    
    [Test]
    public void FilterContainersByGithubCopilotIterationTwo()
    {
        // Arrange
        var filterService = new FilterService();
        
        // Act
        var filteredContainers = filterService.FilterContainersByGithubCopilotIterationTwo(_containerSetOne, _filterSetOne);
        
        // Assert
        filteredContainers.Should().HaveCount(2);
        filteredContainers.Should().ContainSingle(c => c.ContainerId == _containerOne);
        filteredContainers.Should().ContainSingle(c => c.ContainerId == _containerTwo);
    }
}