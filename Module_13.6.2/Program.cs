using System;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Module_13._6._2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Для корректного чтения файла в строку в свойствах файла в Visual Studio должно быть указано "Копировать в выходной каталог" -> "Всегда копировать".
            string text = File.ReadAllText("input2.txt");
            
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            
            // Сохраняем символы-разделители в массив
            char[] delimiters = [' ', '\r', '\n'];
            
            var words = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            var result = words.GroupBy(x => x)
                              .Where(x => x.Count() > 1)
                              .Select(x => new { Word = x.Key, Frequency = x.Count() });

            Dictionary<string, int> DictWords = [];

            foreach (var item in result)
            {
                DictWords.Add(item.Word, item.Frequency);
            }

            var orderedDictWords = DictWords.OrderByDescending(x => x.Value);

            Console.WriteLine("Десять слов, которые встречаются чаще всего в тексте:");
            Console.WriteLine();

            int n = 1;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{n}. Cлово '{orderedDictWords.ElementAt(i).Key}' встречается {orderedDictWords.ElementAt(i).Value} раз");
                n++;
            }
            
            Console.ReadKey();
        }
    }
}
