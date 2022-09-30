string input = Console.ReadLine();

ShowOneByOne(SplitToWords(input));


string[] SplitToWords(string input)
{
    string[] split = input.Split(" ");
    return split;
}

void ShowOneByOne(string[] toShow)
{
    foreach (var item in toShow)
        Console.WriteLine(item);
}