using DbUp;
using System;
using System.Configuration;
using System.Data.Common;
using System.Reflection;

namespace ExamWork.DataAccess
{
    public class DbRepository : IDisposable
    {
        protected DbConnection _connection;
        private DbProviderFactory _providerFactory;

        public DbRepository()
        {
            _providerFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["CountryDb"].ProviderName);
            _connection = _providerFactory.CreateConnection();
            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["CountryDb"].ConnectionString;
            _connection.Open();
        }

        public void UpdateDatabase()
        {
            EnsureDatabase.For.SqlDatabase(ConfigurationManager.ConnectionStrings["CountryDb"].ConnectionString);

            var upgrader = DeployChanges.To
            .SqlDatabase(ConfigurationManager.ConnectionStrings["CountryDb"].ConnectionString)
            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
            .LogToConsole()
            .Build();

            var result = upgrader.PerformUpgrade();
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
