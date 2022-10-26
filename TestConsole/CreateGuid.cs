using System.Runtime.InteropServices;

namespace TestConsole
{
    //добавляем атрибут к классу, объект которого хотим уникально идентифицировать
    //значения записываем самостоятельно, не используя генератор Vusual Studio
    [Guid("00000000-0000-0000-0000-000000000012")]
    class One
    {
        public void TextShow()
        {
            Console.WriteLine("Привет Мир!");
        }
    }
    public class CreateGuid
    {
        public void GetGuidAttribute001()
        {
            //доступ к значению уникального идентификатора через класс Attribute
            //создаем объект класса Attribute и присваиваем ему значение из атрибута
            Attribute At = Attribute.GetCustomAttribute(typeof(One), typeof(GuidAttribute));
            Console.WriteLine(((GuidAttribute)At).Value);

            Console.ReadLine();
        }
        public void GetGuidAttribute002()
        {
            //доступ к значению уникального идентификатора через класс Attribute
            //создаем объект класса Attribute и присваиваем ему значение из атрибута
            Attribute At = Attribute.GetCustomAttribute(typeof(One), typeof(GuidAttribute));

            //доступ к значению уникального идентификатора через структуру Guid
            //создаем объект структуры Guid и инициализируем его значением из атрибута
            Guid G = new Guid(((GuidAttribute)At).Value);
            Console.WriteLine(G);
            Console.ReadLine();
        }
        public void Start()
        {
            Attribute At = Attribute.GetCustomAttribute(typeof(One), typeof(GuidAttribute));
            var guid = new Guid(((GuidAttribute)At).Value);
            Console.WriteLine(guid);

            //var byteArray = guid.ToByteArray();
            //var myByte = byteArray.LastOrDefault();
            var line = Convert.ToString(guid);
            var num = Convert.ToInt64(line.Replace("-", string.Empty));
            Console.WriteLine(num);

            var nextGuid = Guid.Parse(num++.ToString());
            Console.WriteLine(nextGuid);

            Console.ReadLine();
        }
    }
}
