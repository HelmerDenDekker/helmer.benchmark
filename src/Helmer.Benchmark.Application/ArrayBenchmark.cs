using BenchmarkDotNet.Attributes;
using Helmer.Benchmark.Application.Code;

namespace Helmer.Benchmark.Application;

public class ArrayBenchmark
{
	[Benchmark(Baseline = true)]
	public void TestWithArray() => ArrayTest.TestWithArray();

	[Benchmark]
	public void TestWithoutArray() => ArrayTest.TestWithoutArray();
}