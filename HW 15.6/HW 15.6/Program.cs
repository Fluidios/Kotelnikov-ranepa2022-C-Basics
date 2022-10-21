using System.Collections;

List<int> list = new List<int>();
Random random = new Random();

FillWithRandomInts(list, 0, 100, 25);
PrintToConsole(list);
RemoveByRule(list, (int item) => item > 25 && item < 50);
PrintToConsole(list);


void FillWithRandomInts(List<int> collection, int minRandomValue, int maxRandomValue, int countOfRandomValues)
{
    for (int i = 0; i < countOfRandomValues; i++)
    {
        collection.Add(random.Next(minRandomValue, maxRandomValue));
    }
}

void PrintToConsole(IEnumerable collection)
{
    foreach (var item in collection)
    {
        Console.Write(item?.ToString() + " ");
    }
    Console.WriteLine();
}

void RemoveByRule<T>(List<T> collection, Predicate<T> rule)
{
    for (int i = 0; i < collection.Count; i++)
    {
        if (rule(collection[i]))
        {
            collection.RemoveAt(i);
            i--;
        }
    }
}