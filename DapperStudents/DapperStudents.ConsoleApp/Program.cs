using DapperStudents.ConstantsAndEnums;
using DapperStudents.DataAccess;
using DapperStudents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperStudents.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student()
            {
                FirstName = "hdhc",
                GroupId = 1,
                LastName = "hidhn",
                MiddleName ="jojd"
            };

            TableDataService<Student> tableDataService = new TableDataService<Student>();
            tableDataService.Add(student);

            tableDataService.DeleteById(22);
            tableDataService.UpdateStudent(21, StudentProperties.FirstName, "Alisher");
        }
    }
}
