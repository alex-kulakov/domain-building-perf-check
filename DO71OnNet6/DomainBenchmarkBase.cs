using DO71Net6Model;
using DO71Net6Model.Upgraders;
using Shared;
using Xtensive.Orm;
using Xtensive.Orm.Configuration;

namespace DO71OnNet6
{
  public abstract class DomainBenchmarkBase
  {
    private const string ProviderName = ConnectionInfos.SqlServer.ProviderName;
    private const string ConnectionString = ConnectionInfos.SqlServer.ConnectionString71;

    protected readonly DomainConfiguration initialConfiguration;
    protected readonly DomainConfiguration skipModeConfiguration;
    protected readonly DomainConfiguration recreateModeConfiguration;


    public DomainBenchmarkBase()
    {
      var baseModelType = typeof(TestEntity0);
      initialConfiguration = new DomainConfiguration(ProviderName, ConnectionString);
      // no entities, just metadata tables will be created.
      initialConfiguration.UpgradeMode = DomainUpgradeMode.Recreate;

      recreateModeConfiguration = new DomainConfiguration(ProviderName, ConnectionString);
      recreateModeConfiguration.Types.Register(baseModelType.Assembly, baseModelType.Namespace);
      recreateModeConfiguration.Types.Register(typeof(CustomUpgradeHandler));
      recreateModeConfiguration.UpgradeMode = DomainUpgradeMode.Recreate;

      skipModeConfiguration = new DomainConfiguration(ProviderName, ConnectionString);
      skipModeConfiguration.Types.Register(baseModelType.Assembly, baseModelType.Namespace);
      skipModeConfiguration.Types.Register(typeof(CustomUpgradeHandler));
      skipModeConfiguration.UpgradeMode = DomainUpgradeMode.Skip;
    }
  }
}
