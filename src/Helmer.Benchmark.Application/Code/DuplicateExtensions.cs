namespace Helmer.Benchmark.Application;

public static class DuplicateExtensions
{
    public static bool HasDuplicatesForEach(this List<DuplicateTest> inputs)
    {
        var seenNames = new HashSet<string>();
        foreach (var input in inputs)
        {
            if (!seenNames.Add(input.Name))
            {
                return true; // Duplicate found
            }
        }
        return false; // No duplicates
    }
    
    public static bool HasDuplicatesHash(this List<DuplicateTest> inputs)
    {
        var hash = inputs.ToHashSet();
        
        return hash.Count != inputs.Count;
    }
    
    public static bool HasDuplicatesGroupBy(this List<DuplicateTest> inputs)
    {
        var duplicate = inputs
            .GroupBy(c => c.Name)
            .FirstOrDefault(g => g.Count() > 1);
        return duplicate != null;
    }
    
    public static List<string> GetDuplicatesGroupBy(this List<DuplicateTest> inputs)
    {
        return inputs.GroupBy(x => x.Name).Where(group => group.Count() > 1).Select(group => group.Key).ToList();
    }
    
    public static List<string> GetDuplicatesHashSet(this List<DuplicateTest> inputs)
    {
        var hashSet = new HashSet<string>();
        
        return inputs.Where(e => !hashSet.Add(e.Name)).Select(e => e.Name).ToList();
    }
    
    public static List<string> GetDuplicatesFindAll(this List<DuplicateTest> inputs)
    {
        return inputs.FindAll(item => inputs.Count(x => x.Name == item.Name) > 1)
                     .Select(item => item.Name)
                     .Distinct()
                     .ToList();
    }
    
    public static List<string> GetDuplicatesContains(this List<DuplicateTest> inputs)
    {
        List<string> duplicates = new List<string>();

        for (int i = 0; i < inputs.Count; i++) {
            DuplicateTest item = inputs[i];
            if (inputs.IndexOf(item, i + 1) != -1 && !duplicates.Contains(item.Name)) {
                duplicates.Add(item.Name);
            }
        }

        return duplicates;
    }
    
    public static List<string> GetDuplicatesDictionary(this List<DuplicateTest> inputs)
    {
        Dictionary<string, int> occurrences = new Dictionary<string, int>();
        List<string> duplicates = new List<string>();

        foreach (var item in inputs) {
            if (occurrences.ContainsKey(item.Name)) {
                occurrences[item.Name]++;
                if (occurrences[item.Name] == 2) {
                    duplicates.Add(item.Name);
                }
            } else {
                occurrences.Add(item.Name, 1);
            }
        }

        return duplicates;
    }
    
}

public class DuplicateTest
{
    public int Id { get; set; }
    public string Name { get; set; }
}