namespace CustomList;

public class Program
{
    static void Main(string[] args)
    {
        List<string> strings = new List<string>();
        strings.Add("dd");
        strings.Add("ed");
        strings.Add("ads");
        strings.Add("wd");
        strings.Add("dwq");
        //strings.Remove("");
        strings.ForEach(Console.WriteLine);
        Console.WriteLine("==============================");

        //Console.WriteLine(strings.Capacity);
        //Console.WriteLine(strings.Count);



        CustomList<int> list = new CustomList<int>();
        list.Add(10);
        list.Add(1);
        list.Add(2);
        list.Add(2);
        list.Add(3);
        list.Add(3);
        list.Add(3);
        list.Add(4);
        list.Add(4);


        //Console.WriteLine(list.RemoveAll(x=> x%2 == 0));

        list.Reverse();
        //Console.WriteLine(list.Count);
        Console.WriteLine(list.Capacity);

        list.ForEach(Console.WriteLine);

        //list.ForEach(x => Console.WriteLine(x + 10));
        //list.Clear();
        //Console.WriteLine(list.Contains(12));
        //Console.WriteLine(list.Contains(2));
        //Console.WriteLine(list.Count);
        //Console.WriteLine(list.Remove(12));
        //Console.WriteLine(list.Remove(1));
        //Console.WriteLine(list.RemoveAll(x => x % 2 == 0));
        //Console.WriteLine(list.Find(x => x % 10 == 0));
        //Console.WriteLine(list.IndexOf(18));
        //Console.WriteLine(list.IndexOf(4));

        Console.WriteLine("======================");

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("====================");

        //CustomList<int> newList = list.FindAll(x => x % 2 == 0);
        //foreach (int x in newList)
        //{
        //    Console.WriteLine(x);
        //}

        CustomList<string> list2 = new CustomList<string>(7);
        list2.Add("jdk");
        list2.Add("jdk");
        list2.Add("jdk");
        list2.Add("jdk");
        list2.Add("jdk");
        list2.Add("jdk");
        list2.Add("jdk");
        list2.Add("jdk");





        Console.WriteLine(list2.Capacity);
        Console.WriteLine(list2.Count);
    }
}
