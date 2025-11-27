using BenchmarkDotNet.Running;
using Helmer.Benchmark.Application;
using Helmer.Benchmark.Application.Code;

public class Program
{
	public static void Main(string[] args) => BenchmarkRunner.Run<SelectIdFromListBenchmark>(new ShortRunWithMemoryDiagnoserConfig());
}
