using BenchmarkDotNet.Running;

namespace Helmer.Benchmark.Application;

public abstract class Program
{
	public static void Main(string[] args) => BenchmarkRunner.Run<FilterBenchMark>(new ShortRunWithMemoryDiagnoserConfig());
}