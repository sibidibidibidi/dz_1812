using System;
using System.IO;

namespace ConsoleApp3
{
    class Program
    {
        static void generateNumberList()
        {
            string filepath = "Numbers.txt";
            if (File.Exists(filepath))
            {
                Console.WriteLine("Файл уже створено.");
                return;
            }

            using (var writer = new StreamWriter(filepath))
            {
                for (int number = 1; number <= 500; number++)
                {
                    writer.Write(number);
                    if (number < 500)
                        writer.Write(",");
                }
            }
        }

        static void writeColorList()
        {
            string filepath = "Colors.txt";
            string[] basiccolors = { "Red", "Green", "Black", "White", "Blue" };

            if (File.Exists(filepath))
            {
                Console.WriteLine("Colors.txt уже існує.");
                return;
            }

            File.WriteAllLines(filepath, basiccolors);
        }

        static void checkStringLength()
        {
            string filepath = "StringLength.txt";

            if (!File.Exists(filepath))
            {
                File.Create(filepath).Dispose(); 
            }

            FileInfo fileinfo = new FileInfo(filepath);
            if (fileinfo.Length == 0)
            {
                Console.WriteLine("Файл порожній.");
                return;
            }

            using (var reader = new StreamReader(filepath))
            {
                string line = reader.ReadLine();
                if (line != null)
                    Console.WriteLine($"Довжина рядка: {line.Length}");
            }
        }

        static void Main(string[] args)
        {
            checkStringLength();
            generateNumberList();
            writeColorList();
        }
    }
}

