using System;
using System.Diagnostics;

namespace Module_13._6._1
{
    class Program
    {
        // объявим список в виде статической переменной
        public static List<string> List = [];

        // объявим связанный список в виде статической переменной
        public static LinkedList<string> LinkedList = [];

        static void Main(string[] args)
        {
            //Для корректного чтения файла в строку в свойствах файла в Visual Studio должно быть указано "Копировать в выходной каталог" -> "Всегда копировать".
            string text = File.ReadAllText("input1.txt");

            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

            // Сохраняем символы-разделители в массив
            char[] delimiters = [' ', '\r', '\n'];

            var words = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            // Запустим первый таймер
            var watchOne = Stopwatch.StartNew();

            foreach (var word in words)
            {
                List.Add(word);
            }

            watchOne.Stop();

            // Выведем результат первого таймера
            Console.WriteLine($"Производительность вставки слов из текста в List: {watchOne.Elapsed.TotalMilliseconds}  мс");

            // Запустим второй таймер
            var watchTwo= Stopwatch.StartNew();

            foreach (var word in words)
            {
                LinkedList.AddLast(word);
            }

            watchTwo.Stop();

            // Выведем результат второго таймера
            Console.WriteLine($"Производительность вставки слов из текста в LinkedList: {watchTwo.Elapsed.TotalMilliseconds}  мс");

            Console.ReadKey();
        }
    }
}
