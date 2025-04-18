using BenchmarkDotNet.Attributes;
using Helmer.Benchmark.Application.Code;

namespace Helmer.Benchmark.Application
{
    public class ArrayBenchmark
	{
		private System.Guid _guid = System.Guid.NewGuid();


		[Benchmark(Baseline = true)]
		public void TestWithArray() => ArrayTest.TestWithArray();

		[Benchmark]
		public void GuidTextEnTestwithoutArray() =>ArrayTest.TestWithoutArray();
	}
}
