using DapperStudents.ConstantsAndEnums;
using DapperStudents.DataAccess;
using DapperStudents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperStudents.Services
{
    public static class Menu
    {
        public static UserActions UserActionsMenu()
        {
            do
            {
                try
                {
                    Console.WriteLine("1) Insert Student\n" +
                                      "2) Update Student\n" +
                                      "3) Delete Student By Id");

                    int userAction;

                    if(int.TryParse(Console.ReadLine().Trim(), out userAction))
                    {
                        return (UserActions)userAction;
                    }

                    throw new ArgumentException("Число было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static StudentProperties StudentPropertiesChoseMenu()
        {
            do
            {
                try
                {
                    Console.WriteLine("What do you want to update:\n" +
                                      "1) First name\n" +
                                      "2) Last name\n" +
                                      "3) Middle name\n" +
                                      "4) Group");

                    int property;

                    if(int.TryParse(Console.ReadLine().Trim(), out property))
                    {
                        return (StudentProperties)property;
                    }

                    throw new ArgumentException("Число было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static void ShowAllStudents()
        {
            TableDataService<Student> dataServiceForStudent = new TableDataService<Student>();
            TableDataService<Group> dataServiceForGroup = new TableDataService<Group>();

            var students = dataServiceForStudent.GetAll();
            var groups = dataServiceForGroup.GetAll();

            students.ForEach(f => Console.WriteLine($"{groups.Where(group => group.Id == f.Id)}"));
        }
    }
}
