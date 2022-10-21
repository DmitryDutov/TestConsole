using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public class Exercise004
    {
        public void Start()
        {
            var path = @"C:\Users\ThinkPad\Downloads\olimpiada2022_task4_1_3.txt";

            var text = File.ReadAllText(path);
            var list = text.Split('\n');

            //var order =  list.OrderBy(x => x) .ToList() ; //сортирует по алфавиту

            var groups = list
                .GroupBy(g => g)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList()
                ;

            foreach (var group in groups)
            {
                var count = list.Count(x => x == group); //считаем сколько раз встречается название группы в перечне list
                var strin = $"{count} ==> {group}";
                Console.WriteLine(strin);
            }


            Console.ReadLine();
        }
    }
}
