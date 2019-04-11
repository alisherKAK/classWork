using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;

namespace Market.Models
{
    public class TableDataService<T> : IDisposable
    {
        protected DbConnection _connection;
        private DbProviderFactory _providerFactory;

        public TableDataService()
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

        public void CreateTable()
        {
            //TODO следать реализацию по созданию стандартной таблицы по укаанному типу
            Type type = typeof(T);
            var properties = type.GetProperties().ToList();
            string query = $"if not exists(select 1 from sys.tables where name='{type.Name}s')\n" +
                           $"begin\n" +
                           $"create table {type.Name}s\n" +
                           $"(" +
                           $"Id int identity primary key not null,\n";
            for (int i = 1; i < properties.Count; i++)
            {
                string column = $"{properties[i].Name} ";
                if (properties[i].PropertyType.Name == "String")
                {
                    column += $"nvarchar(50) not null check({properties[i].Name}!=''),\n";
                }
                else if (properties[i].PropertyType.Name == "Int32" ||
                    properties[i].PropertyType.Name == "Int64")
                {
                    column += "int not null,\n";
                    if (properties[i].Name.Contains("Id") || properties[i].Name.Contains("id"))
                    {
                        column = column.Trim('\n');
                        column = column.Trim(',');
                        column += $" references " +
                            $"{properties[i].Name.Remove(properties[i].Name.Length - 2)}s(Id),\n";
                    }
                }
                else if (properties[i].PropertyType.Name == "DateTime")
                {
                    column += "datetime not null,\n";
                }
                else if (properties[i].PropertyType.Name == "Double" ||
                    properties[i].PropertyType.Name == "Single")
                {
                    column += "float not null,\n";
                }
                else if (properties[i].PropertyType.Name == "Boolean")
                {
                    column += "bit not null,\n";
                }
                query += column;
            }
            query = query.Trim('\n');
            query = query.Trim(',');
            query += ")\nend";
            Console.WriteLine(query);
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = query;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (DbException exception)
                {
                    Console.WriteLine(exception.Message);
                    throw;
                }
            }
        }

        public List<T> GetAll()
        {
            Type type = typeof(T);
            var data = new List<T>();
            var properties = type.GetProperties();

            try
            {
                string query = $"select * from {type.Name}s";
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = query;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = (T)Activator.CreateInstance(type);

                            for (int i = 0; i < properties.Length; i++)
                            {
                                properties[i].SetValue(item, reader[i]);
                            }

                            data.Add(item);
                        }
                    }

                }
                return data;
            }
            catch (DbException exception)
            {
                Console.WriteLine(exception.Message);
                return new List<T>();
            }
        }

        public void Add(T item)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();

            using (var command = _connection.CreateCommand())
            {
                string query = $"insert into {type.Name}s values(";
                for (int i = 1; i < properties.Length; i++)
                {
                    if (properties[i].PropertyType.Name == "String" ||
                        properties[i].PropertyType.Name == "string")
                    {
                        query += $"@{properties[i].Name.ToLower()},";
                        DbParameter parameter = command.CreateParameter();
                        parameter.ParameterName = $"@{properties[i].Name.ToLower()}";
                        parameter.Value = properties[i].GetValue(item);
                        parameter.DbType = System.Data.DbType.String;
                        command.Parameters.Add(parameter);
                    }
                    else if (properties[i].PropertyType.Name == "Boolean")
                    {
                        if ((bool)properties[i].GetValue(item) == true)
                            query += "1,";
                        else
                            query += "0,";
                    }
                    else if (properties[i].PropertyType.Name == "DateTime")
                    {
                        query += $"@{properties[i].Name.ToLower()},";
                        DbParameter parameter = command.CreateParameter();
                        parameter.ParameterName = $"@{properties[i].Name.ToLower()}";
                        parameter.Value = properties[i].GetValue(item);
                        parameter.DbType = System.Data.DbType.DateTime;
                        command.Parameters.Add(parameter);
                    }
                    else
                    {
                        query += $"@{properties[i].Name.ToLower()},";
                        DbParameter parameter = command.CreateParameter();
                        parameter.ParameterName = $"@{properties[i].Name.ToLower()}";
                        parameter.Value = properties[i].GetValue(item);
                        command.Parameters.Add(parameter);
                    }
                }
                query = query.Trim(',');
                query += ")";
                Console.WriteLine(query);
                command.CommandText = query;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (DbException exception)
                {
                    if (exception.Message == "Invalid object name 'Tests'.")
                    {
                        CreateTable();
                        Add(item);
                    }
                }
                catch (Exception exception)
                {
                    throw;
                }
            }
        }

        public void DeleteById(int id)
        {
            Type type = typeof(T);
            string query = $"if exists(select 1 from {type.Name}s where Id={id})\n" +
                                $"delete from {type.Name}s where Id={id}";

            using (var command = _connection.CreateCommand())
            {
                command.CommandText = query;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (DbException exception)
                {
                    throw;
                }
                catch (Exception exception)
                {
                    throw;
                }
            }
        }
    }
}
