var path = @"C:\Users\ThinkPad\Downloads\olimpiada2022_task2_2_2.txt";

var text = File.ReadAllText(path);
var list = text.Split('\n');

int num = 1;
var listValueTypel = new List<ValueTuple<int, int, int, string>>();
var maxNum = 0;

foreach (var item in list)
{
    var vloj = item.Split('\\').ToList().Count - 1;
    var name = item.Split('\\').LastOrDefault();
    var lenght = item.Length;
    Console.WriteLine("{0}; {1}; {2}; {3}", lenght, num, vloj, name);

    if (vloj>maxNum)
    {
        maxNum = vloj;
    }

    var obj = (lenght, num, vloj, name);
    listValueTypel.Add(obj);

    num++;
}

var result = listValueTypel.Select(x => x).Where(x => x.Item3 == maxNum).ToList().FirstOrDefault();
Console.WriteLine($"Result: {result.Item3} {result.Item4}");

Console.ReadLine();

