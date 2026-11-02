namespace Helmer.Benchmark.Application.Code;

public class FilterService
{
    public List<Container> FilterContainersByGithubCopilot(List<Container> containers, List<Filter> filters)
    {
        if (filters.Count == 0)
        {
            return containers;
        }

        var filterGroups = filters
            .GroupBy(f => f.FilterId)
            .ToDictionary(g => g.Key, g => g.ToList());

        var filteredContainers = new List<Container>();

        foreach (var container in containers)
        {
            var valuesByFilterId = container.Properties
                .GroupBy(p => p.FilterId)
                .ToDictionary(
                    g => g.Key,
                    g => g
                        .Select(p => int.TryParse(p.Value, out var parsedValue) ? (int?)parsedValue : null)
                        .Where(v => v.HasValue)
                        .Select(v => v!.Value)
                        .ToList());

            var matchesAllFilterGroups = true;
            foreach (var filterGroup in filterGroups)
            {
                if (!valuesByFilterId.TryGetValue(filterGroup.Key, out var candidateValues))
                {
                    matchesAllFilterGroups = false;
                    break;
                }

                var matchesAnyInGroup = candidateValues.Any(candidateValue =>
                    filterGroup.Value.Any(filter =>
                        EvaluateCondition(candidateValue, filter.Condition, filter.Value)));

                if (!matchesAnyInGroup)
                {
                    matchesAllFilterGroups = false;
                    break;
                }
            }

            if (matchesAllFilterGroups)
            {
                filteredContainers.Add(container);
            }
        }

        return filteredContainers;
    }
    
    public List<Container> FilterContainersByGithubCopilotIterationTwo(List<Container> containers, List<Filter> filters)
    {
        if (filters.Count == 0)
            return containers;

        var groups = filters.GroupBy(f => f.FilterId).ToDictionary(g => g.Key, g => g.ToList());

        var result = new List<Container>(containers.Count);

        foreach (var container in containers)
        {
            bool ok = true;

            foreach (var group in groups)
            {
                var property = container.Properties.FirstOrDefault(p => p.FilterId == group.Key);
                if (property == null || !group.Value.Any(f => EvaluateCondition(property.Value, f.Condition, f.Value)))
                {
                    ok = false;
                    break;
                }
            }

            if (ok) result.Add(container);
        }

        return result;
    }
    
    public List<Container> FilterContainersForEachByGroupReduceList(List<Container> containers, List<Filter> filters)
    {
        if (filters.Count == 0)
        {
            return containers;
        }
        
        var resultingContainers = new List<Container>();
        resultingContainers.AddRange(containers);
        
        // first group the filters by FilterId for efficient lookup
        var filterGroups = filters
            .GroupBy(f => f.FilterId)
            .ToDictionary(g => g.Key, g => g.ToList());
        
        foreach (var filterGroup in filterGroups)
        {
            var filterId = filterGroup.Key;
            var groupFilters = filterGroup.Value;

            foreach (var container in resultingContainers.ToList())
            {
                var property = container.Properties.FirstOrDefault(p => p.FilterId == filterId);
                
                if (property == null)
                {
                    resultingContainers.Remove(container);
                    continue;
                }

                if (!groupFilters.Any(f => EvaluateCondition(property.Value, f.Condition, f.Value)))
                {
                    resultingContainers.Remove(container);
                }
            }
        }
        return resultingContainers;
    }
    

    private bool EvaluateCondition(string propertyValue, LogicCondition filterCondition, int filterValue)
    {
        if (!int.TryParse(propertyValue, out var parsedValue))
            return false;

        return EvaluateCondition(parsedValue, filterCondition, filterValue);
    }

    private bool EvaluateCondition(int parsedValue, LogicCondition filterCondition, int filterValue)
    {
        switch (filterCondition)
        {
            case LogicCondition.Equal:
                return parsedValue == filterValue;
            case LogicCondition.GreaterThan:
                return parsedValue > filterValue;
            case LogicCondition.LessThan:
                return parsedValue < filterValue;
            case LogicCondition.GreaterThanOrEqual:
                return parsedValue >= filterValue;
            case LogicCondition.LessThanOrEqual:
                return parsedValue <= filterValue;
            default:
                throw new ArgumentOutOfRangeException(nameof(filterCondition), filterCondition, null);
        }
    }

    public List<Container> FilterContainersByMsCopilot(List<Container> containers, List<Filter> filters)
    {
        if (filters.Count == 0)
        {
            return containers;
        }
        
        var filterGroups = filters.GroupBy(f => f.FilterId);

        var result = containers.Where(container =>
            filterGroups.All(group =>
                container.Properties.Any(property =>
                    property.FilterId == group.Key &&
                    group.Any(filter => EvaluateCondition(property.Value, filter.Condition, filter.Value))
                )
            ));
        
        return [.. result];
    }
}

public class Filter
{
    public Guid FilterId { get; set; }
    public LogicCondition Condition { get; set; }
    public int Value { get; set; }
}

public class Property
{
    public Guid FilterId { get; set; }
    public string Value { get; set; } = string.Empty;
}

/// <summary>
/// Wrapper around a collection of properties to be collected in filtering operations.
/// </summary>
public class Container
{ 
    public string Name { get; set; } = string.Empty;
    public Guid ContainerId { get; set; }
    public List<Property> Properties { get; set; } = new List<Property>();
}

public enum LogicCondition
{
    Equal,
    GreaterThan,
    LessThan,
    GreaterThanOrEqual,
    LessThanOrEqual,
}