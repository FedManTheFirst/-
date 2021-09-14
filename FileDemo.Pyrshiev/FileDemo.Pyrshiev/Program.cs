using System;
using System.IO;
namespace FileDemo.Pyrshiev
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 lesson
            StreamWriter writer = File.CreateText(@"c:\Проба пера.txt");
            writer.WriteLine("Это Федя балуется, чтобы разобраться в функионале");
            writer.WriteLine(":3");
            writer.Close();
            // 2 lesson
            StreamReader reader = File.OpenText(@"c:\Проба пера.txt");
            string contents = reader.ReadToEnd();
            reader.Close();
            Console.WriteLine(contents);
        }
    }
}
