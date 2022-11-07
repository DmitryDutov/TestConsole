using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public class Test
    {
        public async Task TextReadAsync()
        {
            var path = @"C:\Users\ThinkPad\Downloads\!License-8.sll";
            var formatter = "{0,25}{1,30}";

            using (FileStream fstream = File.OpenRead(path))
            {
                // выделяем массив для считывания данных из файла
                byte[] buffer = new byte[fstream.Length];
                // считываем данные
                await fstream.ReadAsync(buffer, 0, buffer.Length);
                // декодируем байты в строку
                string textFromFile = Encoding.UTF8.GetString(buffer);
                var result = BitConverter.ToString(buffer);
                //foreach (var item in buffer)
                //{
                //    Console.WriteLine(formatter, item, BitConverter.ToString(BitConverter.GetBytes(item)));
                //}
                Console.WriteLine(result);
            }

            Console.ReadLine();
        }
    }
}

