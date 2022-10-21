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
            var path = @"C:\Users\ThinkPad\Downloads\olimpiada2022_task4_1_1.txt";

            var text = File.ReadAllText(path);
            var list = text.Split('\n');

            var result = list.OrderByDescending(g=>g).ToList();


            Console.ReadLine();
        }
    }
}
