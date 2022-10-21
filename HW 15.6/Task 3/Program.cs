HashSet<int> set = new HashSet<int>();

for (int i = 0; i < 5; i++)
{
    Console.WriteLine("Введите число:");
    int value = int.Parse(Console.ReadLine());
    if (set.Contains(value))
    {
        Console.WriteLine("Данное число уже представлено в хеш-сете");
    }
    else
    {
        set.Add(value);
        Console.WriteLine("Число добавлено в хеш-сет");
    }
}
