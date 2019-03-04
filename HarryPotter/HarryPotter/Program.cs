using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace HarryPotter
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.DefaultValueHandling = DefaultValueHandling.Ignore;

            string result;

            WebRequest request = WebRequest.Create("http://hp-api.herokuapp.com/api/characters");
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }
            response.Close();

            var characters = JsonConvert.DeserializeObject<List<Characters>>(result, settings);

            foreach(Characters chararcter in characters)
            {
                Console.WriteLine($"{chararcter.Name}, {chararcter.Species}, {chararcter.Gender}, {chararcter.House}, {chararcter.DateOfBirth}, {chararcter.YearOfBirth}," +
                    $"{chararcter.Ancestry}, {chararcter.EyeColour}, {chararcter.HairColour}");
            }
            Console.WriteLine();
            Console.WriteLine();


            request = WebRequest.Create("http://hp-api.herokuapp.com/api/characters/students");
            response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }
            response.Close();

            var students = JsonConvert.DeserializeObject<List<Student>>(result, settings);

            foreach (Student student in students)
            {
                Console.WriteLine($"{student.Name}, {student.Species}, {student.Gender}, {student.House}, {student.DateOfBirth}, {student.YearOfBirth}," +
                    $"{student.Ancestry}, {student.EyeColour}, {student.HairColour}");
            }
            Console.WriteLine();
            Console.WriteLine();



            request = WebRequest.Create("http://hp-api.herokuapp.com/api/characters/staff");
            response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }
            response.Close();

            var staffs = JsonConvert.DeserializeObject<List<Staff>>(result, settings);

            foreach (Staff staff in staffs)
            {
                Console.WriteLine($"{staff.Name}, {staff.Species}, {staff.Gender}, {staff.House}, {staff.DateOfBirth}, {staff.YearOfBirth}," +
                    $"{staff.Ancestry}, {staff.EyeColour}, {staff.HairColour}");
            }
            Console.WriteLine();
            Console.WriteLine();


            request = WebRequest.Create("http://hp-api.herokuapp.com/api/characters/house/gryffindor");
            response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }
            response.Close();

            var gryffendors = JsonConvert.DeserializeObject<List<Gryffendor>>(result, settings);

            foreach (Gryffendor gryffendor in gryffendors)
            {
                Console.WriteLine($"{gryffendor.Name}, {gryffendor.Species}, {gryffendor.Gender}, {gryffendor.House}, {gryffendor.DateOfBirth}, {gryffendor.YearOfBirth}," +
                    $"{gryffendor.Ancestry}, {gryffendor.EyeColour}, {gryffendor.HairColour}");
            }

            Console.ReadLine();
        }
    }
}
