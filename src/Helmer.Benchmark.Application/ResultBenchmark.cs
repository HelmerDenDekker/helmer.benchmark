using BenchmarkDotNet.Attributes;


namespace Helmer.Benchmark.Application;

    public class ResultBenchmark
	{
		
		[Benchmark(Baseline = true)]
		public void ResultVersionOne() => Code.V1.ResultTest.TestCreateQueryType();

		[Benchmark]
        public void ResultVersionTwo() => Code.V2.ResultTest.TestCreateQueryType();

    }
