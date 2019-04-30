using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace HomeWork10_05_19.DataAccess
{
    public class TableDataService<T>
    {
        private string _connectionString;

        public TableDataService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["NewsDb"].ConnectionString;
        }

        public TableDataService(string connectionString)
        {
            _connectionString = connectionString;
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

            using (var sql = new SqlConnection(_connectionString))
            {
                sql.Execute(query);
            }
        }

        public List<T> GetAll()
        {
            Type type = typeof(T);
            var data = new List<T>();
            var properties = type.GetProperties();

            string query = $"select * from {type.Name}s";
            using (var sql = new SqlConnection(_connectionString))
            {
                data = sql.Query<T>(query).ToList();
            }
            return data;
        }

        public void Add(T item)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();

            string query = $"insert into {type.Name}s values(";
            for (int i = 1; i < properties.Length; i++)
            {
                if (properties[i].PropertyType.Name == "String" ||
                    properties[i].PropertyType.Name == "string")
                {
                    query += $"@{properties[i].Name},";
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
                    query += $"@{properties[i].Name},";
                }
                else
                {
                    query += $"@{properties[i].Name},";
                }
            }
            query = query.Trim(',');
            query += ")";

            using (var sql = new SqlConnection(_connectionString))
            {
                sql.Execute(query, item);
            }
        }

        public void DeleteById(Guid id)
        {
            Type type = typeof(T);
            string query = $"if exists(select 1 from {type.Name}s where Id={id})\n" +
                                $"delete from {type.Name}s where Id={id}";

            using (var sql = new SqlConnection(_connectionString))
            {
                sql.Execute(query);
            }
        }
    }
}
