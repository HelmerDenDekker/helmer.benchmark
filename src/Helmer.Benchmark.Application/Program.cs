using BenchmarkDotNet.Running;
using Helmer.Benchmark.Application;

public class Program
{
	public static void Main(string[] args) => BenchmarkRunner.Run<DuplicatesBenchMark>(new ShortRunWithMemoryDiagnoserConfig());
}
