using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ReflectionLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFile(@"C:\Users\калабаева\source\repos\ClassLibrary1\ClassLibrary1\bin\Debug\ClassLibrary1.dll");
            foreach(Type type in assembly.GetTypes())
            {
                //typeof(Program)
                Console.WriteLine(type.FullName);

                foreach(var member in type.GetMembers())
                {
                    Console.WriteLine($"{member.Name}");

                    if(member is MethodInfo && member.Name == "SendMessage")
                    {
                        var method = member as MethodInfo;
                        object messageService = Activator.CreateInstance(type);

                        method.Invoke(messageService, new object[0]);
                    }
                }
            }
        }
    }
}
