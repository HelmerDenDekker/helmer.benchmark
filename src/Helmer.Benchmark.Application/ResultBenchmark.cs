using BenchmarkDotNet.Attributes;
using Helmer.Benchmark.Application.Code.V1;

namespace Helmer.Benchmark.Application;

public class ResultBenchmark
{
	[Benchmark(Baseline = true)]
	public void ResultVersionOne() => ResultTest.TestCreateQueryType();

	[Benchmark]
	public void ResultVersionTwo() => Code.V2.ResultTest.TestCreateQueryType();
}
