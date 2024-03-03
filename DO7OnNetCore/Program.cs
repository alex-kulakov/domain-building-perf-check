using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using DO7NetCoreModel;
using Xtensive.Orm;

namespace DO7OnNetCore
{
  internal class Program
  {
    static void Main(string[] args)
    {
      //IMPORTANT! To eliminate impact of caches we need to run each benchmark as single run
      // uncomment needed run before launching

      //_ = BenchmarkRunner.Run<DomainInSkipBenchmark>(ManualConfig
      //  .Create(DefaultConfig.Instance)
      //  .AddJob(Job.Dry.WithWarmupCount(0))); // single run no warm up

      _ = BenchmarkRunner.Run<DomainInRecreateBenchmark>(ManualConfig
        .Create(DefaultConfig.Instance)
        .AddJob(Job.Dry.WithWarmupCount(0))); // single run no warm up

      Console.ReadLine();
    }
  }

  [MemoryDiagnoser]
  [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.Declared)]
  public class DomainInSkipBenchmark : DomainBenchmarkBase
  {

    [Benchmark]
    public void Build()
    {
      Domain domain;
      try
      {
        domain = Domain.Build(skipModeConfiguration);
        domain.Dispose();
      }
      catch (InterruptBuildException)
      {
      }
    }

    public DomainInSkipBenchmark()
      : base()
    {
    }
  }

  [MemoryDiagnoser]
  [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.Declared)]
  public class DomainInRecreateBenchmark : DomainBenchmarkBase
  {
    [Benchmark]
    public void Build()
    {
      Domain domain;
      try
      {
        domain = Domain.Build(recreateModeConfiguration);
        domain.Dispose();
      }
      catch (InterruptBuildException)
      {
      }
    }

    public DomainInRecreateBenchmark()
      : base()
    {
    }
  }
}
