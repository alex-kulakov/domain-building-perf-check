using System;

namespace Shared
{
  public static class ConnectionInfos
  {
    public static class SqlServer
    {
      public const string ProviderName = "sqlserver";
      public const string ConnectionString = @"Data Source=ALEXEYKULAKOVPC\MSSQL2016;Initial Catalog=DO-Tests;User Id=dotest;Password=dotest;MultipleActiveResultSets=True;";
      public const string ConnectionString71 = @"Data Source=ALEXEYKULAKOVPC\MSSQL2016;Initial Catalog=DO-Tests;User Id=dotest;Password=dotest;MultipleActiveResultSets=True;Encrypt=false;";
    }
  }
}
