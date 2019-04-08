using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace Hotel.DataAccess
{
    public class DbRepository : IDisposable
    {
        protected DbConnection _connection;
        private DbProviderFactory _providerFactory;

        public DbRepository()
        {
            _providerFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["TestDbConnectionString"].ProviderName);
            _connection = _providerFactory.CreateConnection();
            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["TestDbConnectionString"].ConnectionString;
            _connection.Open();
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
