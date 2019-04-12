using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Student.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 создания базы данных
            DataSet studentsDb = new DataSet("StudentsDb");

            //2 создание таблиц
            DataTable students = new DataTable("Students");
            DataTable gender = new DataTable("Gender");

            //3 создание полей
            InitStudent(ref students);
            InitGender(ref gender);

            ForeignKeyConstraint FK_Gender = new ForeignKeyConstraint(gender.Columns["Id"], students.Columns["GenderId"]);
            //{
            //    DeleteRule = Rule.Cascade,
            //    UpdateRule = Rule.Cascade
            //};
            students.Constraints.Add(FK_Gender);

            studentsDb.Tables.AddRange(new DataTable[] { gender, students });

            DataRow newRow = gender.NewRow();
            newRow["Name"] = "Male";
            gender.Rows.Add(newRow);

            newRow = gender.NewRow();
            newRow["Name"] = "Female";
            gender.Rows.Add(newRow);

            gender.WriteXml("gender.xml");

            InsertStudent(ref students);
            students.WriteXml("students.xml");
            Console.ReadLine();
        }

        private static void InitGender(ref DataTable gender)
        {
            DataColumn id = new DataColumn("Id", typeof(int));
            id.AllowDBNull = false;
            id.AutoIncrement = true;
            id.AutoIncrementSeed = 1;
            id.AutoIncrementStep = 1;
            id.Caption = "Идентификатор";
            id.Unique = true;
            id.ReadOnly = true;

            DataColumn name = new DataColumn("Name", typeof(string));
            name.AllowDBNull = false;
            name.Caption = "Имя пола";
            name.Unique = true;
            name.MaxLength = 20;

            gender.Columns.AddRange(new DataColumn[] { id, name });

            gender.PrimaryKey = new DataColumn[] { gender.Columns["Id"] };
        }

        private static void InitStudent(ref DataTable students)
        {
            DataColumn id = new DataColumn("Id", typeof(int));
            id.AllowDBNull = false;
            id.AutoIncrement = true;
            id.AutoIncrementSeed = 1;
            id.AutoIncrementStep = 1;
            id.Caption = "Идентификатор";
            id.Unique = true;
            id.ReadOnly = true;

            DataColumn fio = new DataColumn("FIO", typeof(string));
            fio.AllowDBNull = false;
            fio.Caption = "ФИО студента";
            fio.MaxLength = 60;

            DataColumn genderId = new DataColumn("GenderId", typeof(int))
            {
                AllowDBNull = false,
                Caption = "Пол"
            };

            students.Columns.AddRange(new DataColumn[] { id, fio, genderId });

            students.PrimaryKey = new DataColumn[] { students.Columns["Id"] };
        }

        private static void InsertStudent(ref DataTable student)
        {
            DataRow newRow = student.NewRow();
            newRow["FIO"] = SetInformation.SetFIO();
            newRow["GenderId"] = SetInformation.SetGender();
            student.Rows.Add(newRow);
        }
    }
}
