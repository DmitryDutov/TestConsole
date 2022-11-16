using System.Text;

namespace TestConsole
{
    public class Test
    {
        public void TestFolder()
        {
            var dir = Directory.GetFiles(@"C:\Test\F-001");
            if (dir.Length != 0)
            {
                foreach (var item in dir)
                {
                    Console.WriteLine(item);
                    Task.Run(() =>
                    {
                        MoveFile(item);
                    });
                }
            }

            Console.ReadLine();
        }
        public async Task TextReadAsync()
        {
            var path = @"C:\Users\ThinkPad\Downloads\!License-8.sll";
            //var formatter = "{0,25}{1,30}";
            using (FileStream fstream = File.OpenRead(path))
            {
                // выделяем массив для считывания данных из файла
                byte[] buffer = new byte[fstream.Length];
                // считываем данные
                fstream.ReadAsync(buffer, 0, buffer.Length);
                // декодируем байты в строку
                string textFromFile = Encoding.ASCII.GetString(buffer);
                //var result = BitConverter.ToString(buffer);

                //foreach (var item in result)
                //{
                //    var line = Convert.ToByte(item);
                //    var symb = BitConverter.GetBytes(line);
                //    Console.WriteLine($"{line} ==> {symb}");
                //}
                Console.WriteLine(textFromFile);
            }

            Console.ReadLine();
        }

        public void Next()
        {
            byte[] name = { 86, 79, 76, 49, 48, 48, 48, 119, 54, 76, 0, 0, 22, 0, 0, 0, 49, 50, 47, 50, 51, 47, 50, 48, 50, 49, 32, 49, 48, 58, 49, 55, 58, 53, 52, 32, 65, 77, 28, 0, 0, 0, 86, 105, 115, 117, 97, 108, 32, 83, 109, 97, 108, 108, 116, 97, 108, 107, 32, 46, 46, 46, 32, 76, 105, 99, 101, 110, 115, 101, 36, 1, 0, 0, 0, 0, 0, 0, 8, 167, 254, 1, 8, 0, 0, 0, 190, 0, 0, 0, 14, 1, 0, 0, 110, 0, 0, 0, 126, 0, 0, 0, 174, 0, 0, 0, 70, 0, 0, 0, 158, 0, 0, 0, 142, 0, 0, 0, 11, 107, 245, 49, 24, 0, 0, 0, 68, 105, 99, 116, 105, 111, 110, 97, 114, 121, 0, 0, 2, 245, 43, 97, 16, 0, 0, 0, 19, 0, 0, 0, 206, 0, 0, 0, 16, 234, 87, 49, 24, 0, 0, 0, 76, 105, 110, 101, 97, 114, 72, 97, 115, 104, 84, 97, 98, 108, 101, 0, 2, 151, 170, 97, 16, 0, 0, 0, 19, 0, 0, 0, 250, 0, 0, 0, };
            Encoding koi = Encoding.UTF8;
            var str = koi.GetString(name);

            Console.WriteLine(str);
            Console.ReadLine();
        }

        private static async Task MoveFile(string currentDir)
        {
            var targetDir = @"C:\Test\F-002\";
            var name = Path.GetFileName(currentDir);

            targetDir = $"{targetDir}{name}";
            File.Move(currentDir, targetDir);

            Console.ReadLine();
        }

        public void WacthFile()
        {
            var currentDir = @"C:\Test\F-001";
            using var watcher = new FileSystemWatcher(currentDir);

            watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

            watcher.Changed += OnChanged;
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
            watcher.Renamed += OnRenamed;
            watcher.Error += OnError;

            watcher.Filter = "*.txt";
            watcher.EnableRaisingEvents = true;

            Console.ReadLine();
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            Console.WriteLine($"Changed: {e.FullPath}");
            Task.Run(() =>
            {
                MoveFile(e.FullPath);
            });
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            string value = $"Created: {e.FullPath}";
            Console.WriteLine(value);
            Task.Run(() =>
            {
                MoveFile(e.FullPath);
            });
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e) =>
            Console.WriteLine($"Deleted: {e.FullPath}");

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"Renamed:");
            Console.WriteLine($"    Old: {e.OldFullPath}");
            Console.WriteLine($"    New: {e.FullPath}");
            Task.Run(() =>
            {
                MoveFile(e.FullPath);
            });
        }

        private static void OnError(object sender, ErrorEventArgs e) =>
            PrintException(e.GetException());

        private static void PrintException(Exception? ex)
        {
            if (ex != null)
            {
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine("Stacktrace:");
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine();
                PrintException(ex.InnerException);
            }
        }
    }
}

