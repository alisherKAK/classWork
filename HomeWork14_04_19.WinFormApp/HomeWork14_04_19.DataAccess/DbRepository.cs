using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;

namespace HomeWork14_04_19.DataAccess
{
    public class DbRepository : IDisposable
    {
        protected DbConnection _connection;
        private DbProviderFactory _providerFactory;

        public DbRepository()
        {
            _providerFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["SalesDataBase"].ProviderName);
            _connection = _providerFactory.CreateConnection();
            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["SalesDataBase"].ConnectionString;
            _connection.Open();
        }

        public void Dispose()
        {
            _connection.Close();
        }

        public List<string> GetTables()
        {
            List<string> tables = new List<string>();
            string query = "select * from sysobjects where xtype='U'";

            using (var command = _connection.CreateCommand())
            {
                command.CommandText = query;
                try
                {
                    DbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        tables.Add(reader.GetString(0));
                    }

                    return tables;
                }
                catch (DbException exception)
                {
                    Console.WriteLine(exception.Message);
                    throw;
                }
            }
        }
    }
}