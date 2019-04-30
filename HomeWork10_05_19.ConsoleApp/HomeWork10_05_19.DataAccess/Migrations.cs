using DbUp;
using System.Configuration;
using System.Reflection;

namespace HomeWork10_05_19.DataAccess
{
    public static class Migrations
    {
        public static void UpdateDatabase()
        {

            EnsureDatabase.For.SqlDatabase(ConfigurationManager.ConnectionStrings["NewsDb"].ConnectionString);

            var upgrader = DeployChanges.To
            .SqlDatabase(ConfigurationManager.ConnectionStrings["NewsDb"].ConnectionString)
            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
            .Build();

            var result = upgrader.PerformUpgrade();
        }
    }
}
