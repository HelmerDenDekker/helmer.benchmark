using BenchmarkDotNet.Attributes;
using Helmer.Benchmark.Application.Code;
using Microsoft.AspNetCore.WebUtilities;

namespace Helmer.Benchmark.Application;
    public class GuidBenchmark
	{
		private Guid _guid = Guid.NewGuid();


		[Benchmark(Baseline = true)]
		public void GuidConvert() => Convert.ToBase64String(_guid.ToByteArray()).Replace("/", "-").Replace("+", "_").Replace("=", "");

		[Benchmark]
		public void GuidTextEncode() => Base64UrlTextEncoder.Encode(_guid.ToByteArray());

		[Benchmark]
		public void GuidReneEncode() => _guid.ToString("N");

        [Benchmark]
        public void GuidEncode() => _guid.EncodeBase64String();
	}

