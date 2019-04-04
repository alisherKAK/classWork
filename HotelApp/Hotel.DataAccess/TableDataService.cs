using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DataAccess
{
    public class TableDataService<T> : DbRepository
    {
        public void CreateTable()
        {
            //TODO следать реализацию по созданию стандартной таблицы по укаанному типу
            Type type = typeof(T);
            var properties = type.GetProperties().ToList();
            string query = $"create table {type.Name}s" +
                           $"(" +
                           $"Id int identity primary key not null,";
            for(int i = 1; i < properties.Count; i++)
            {
                Console.WriteLine($"{properties[i].Name}, {properties[i].PropertyType.Name}");
                string column = $"{properties[i].Name} not null";
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
            catch(DbException exception)
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
                    if (properties[i].GetValue(item).GetType().Name == "String" ||
                        properties[i].GetValue(item).GetType().Name == "string")
                    {
                        query += $"@{properties[i].Name.ToLower()},";
                        DbParameter parameter = command.CreateParameter();
                        parameter.ParameterName = $"@{properties[i].Name.ToLower()}";
                        parameter.Value = properties[i].GetValue(item);
                        parameter.DbType = System.Data.DbType.String;
                        command.Parameters.Add(parameter);
                    }
                    else if (properties[i].GetValue(item).GetType().Name == "Boolean")
                    {
                        if ((bool)properties[i].GetValue(item) == true)
                            query += "1,";
                        else
                            query += "0,";
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
                catch(DbException exception)
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