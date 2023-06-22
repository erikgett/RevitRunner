using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace journale_cleaner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Оставил перемынные такими для своего комфорта далее заменяются консольным вводом
            string filePath = @"C:\Users\gette.e\AppData\Roaming\Autodesk\Revit\Addins\2021\journal.0004.txt"; // Замените на фактический путь к вашему файлу
            string outPath = @"C:\Users\gette.e\AppData\Roaming\Autodesk\Revit\Addins\2021\journall.0004.txt";

            Console.WriteLine("Введите путь к журналу");
            filePath = Console.ReadLine();
            outPath = Path.GetFileName(filePath);

            try
            {
                Encoding win1251 = Encoding.GetEncoding("windows-1251");
                string[] lines = File.ReadAllLines(filePath, win1251);

                // Создаем регулярное выражение для поиска строк, начинающихся с символа ' или этот символ первый после пробелов
                Regex regex = new Regex(@"^\s*'");

                // Отфильтровываем строки и сохраняем только те, которые не соответствуют регулярному выражению
                lines = Array.FindAll(lines, line => !regex.IsMatch(line));
                List<string> modifiedLines = new List<string>(lines);
                modifiedLines.Insert(0, "'");
                // Записываем изменения обратно в файл
                File.WriteAllLines(outPath, modifiedLines, win1251);
            }
            catch { }
        }
    }
}
