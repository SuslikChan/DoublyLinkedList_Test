using LIST_test.list_model;

internal class Program
{
    private static void Main(string[] args)
    {
        ListRandom LIST = new ListRandom();

        //Проерка создания списка через Append
        LIST.Append("11");
        LIST.Append("45");
        LIST.Append("13");
        LIST.Append("12");

        //Прверка доступа к элементам списка
        Console.WriteLine(LIST.GetText(1));
        Console.WriteLine(LIST.GetNode(2).Random.Data);

        
        Console.WriteLine(LIST.List2Sting());             //Конвертация списка в строку
        LIST.String2List("it just works", separator:" "); //Конвертация строки в список
        Console.WriteLine(LIST.List2Sting(separator: "##"));

        // Проверка сериализации и десериализации 
        string path_ser =   @"D:\output.txt";
        string path_deser = @"D:\input.txt";
        Stream s_ser = new FileStream(path_ser, FileMode.Create);
        Stream s_deser = new FileStream(path_deser, FileMode.Open);

        LIST.Append("nice");
        LIST.Serialize(s_ser);

        LIST.Deserialize(s_deser);
        Console.WriteLine(LIST.List2Sting());
    }
}