using System.Runtime.InteropServices;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Filters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;
#if Windows_NT
using System.Security.Principal;
using BenchmarkDotNet.Diagnostics.Windows;
#endif

namespace Helmer.Benchmark.Application;

public class ShortRunWithMemoryDiagnoserConfig : ManualConfig
{
    public ShortRunWithMemoryDiagnoserConfig()
    {
        AddJob(Job.ShortRun
            .WithWarmupCount(5)
            .WithIterationCount(25)
            .WithArguments(new Argument[]
            {
				// See https://github.com/dotnet/roslyn/issues/42393
				new MsBuildArgument("/p:DebugType=portable")
            }));

        AddColumnProvider(DefaultColumnProviders.Instance);
        AddLogger(ConsoleLogger.Default);
        AddExporter(MarkdownExporter.GitHub);
        AddDiagnoser(MemoryDiagnoser.Default);
    }
}
