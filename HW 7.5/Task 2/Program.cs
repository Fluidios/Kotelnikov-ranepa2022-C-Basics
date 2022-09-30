string input = Console.ReadLine();

Console.WriteLine(Reverse(input));


string Reverse(string input)
{
    string result = string.Empty;
    foreach (var item in SplitToWords(input).Reverse())
        result += item + " ";
    return result;
}

string[] SplitToWords(string input)
{
    string[] split = input.Split(" ");
    return split;
}