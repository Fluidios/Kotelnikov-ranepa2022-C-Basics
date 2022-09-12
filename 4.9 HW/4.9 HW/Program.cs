

#region Task 1
Console.WriteLine("Введите число для исследования...");
string str = Console.ReadLine();
int value = int.Parse(str);
if (value % 2 > 0)
    Console.WriteLine("Число нечётное");
else
    Console.WriteLine("Число чётное");
#endregion

#region Tak 2
Console.WriteLine("Эта программа приветствует вас и спрашивает сколько карт у вас на руках?");
int counter = int.Parse(Console.ReadLine());
int summ = 0, value2;
for (int i = 0; i < counter; i++)
{
    Console.WriteLine("Введите номинал вашей {0} карты...", i + 1);
    string s = Console.ReadLine();
    if (int.TryParse(s, out value2))
    {
        if (value2 > 5 && value2 < 11)
            summ += value2;
        else
        {
            Console.WriteLine("Введенная строка не распознана. \nВведите целое число от 6 до 10 либо одно из следующих кратких обозначений \"J\",\"Q\",\"K\",\"T\", для карт высокого номинала.");
            i--;
        }
    }
    else
        switch (s)
        {
            case "J":
                summ += 10;
                break;
            case "Q":
                summ += 10;
                break;
            case "K":
                summ += 10;
                break;
            case "T":
                summ += 10;
                break;
            default:
                Console.WriteLine("Введенная строка не распознана. \nВведите целое число от 6 до 10 либо одно из следующих кратких обозначений \"J\",\"Q\",\"K\",\"T\", для карт высокого номинала.");
                i--;
                break;
        }
}
Console.WriteLine("Сумма баллов: {0}", summ);
#endregion

#region Task 3
int N = int.Parse(Console.ReadLine());
int j = 2; bool result1 = false;
while (j != N && N > j)
{
    if (N % j == 0)
    {
        result1 = true;
        break;
    }
    j++;
}
if (!result1)
    Console.WriteLine("Число {0} - является простым.", N);
else
    Console.WriteLine("Число {0} - не является простым.", N);
#endregion

#region Task 4
int inputLength = int.Parse(Console.ReadLine());
int minValue = int.MaxValue;
int value4;
for (int i = 0; i < inputLength; i++)
{
    value4 = int.Parse(Console.ReadLine());
    if (minValue > value4)
        minValue = value4;
}
Console.WriteLine(minValue.ToString());
#endregion

#region 5
int maxValue = int.Parse(Console.ReadLine());
Random rnd = new Random();
int secretNumber = rnd.Next(0, maxValue);
int value5; string str5;
do
{
    str5 = Console.ReadLine();

    if (str5.Equals(string.Empty))
    {
        break;
    }
    else if (int.TryParse(str5, out value5))
    {
        if (value5 > secretNumber)
            Console.WriteLine("Загаданное число меньше того что ввели вы.");
        else if (value5 < secretNumber)
            Console.WriteLine("Загаданное число больше того что ввели вы.");
    }
    else
        Console.WriteLine("Не распознано, повторите ввод.");
}
while (value5 != secretNumber);

if(str5.Length < 1)
    Console.WriteLine("Defeat!");
else
    Console.WriteLine("Вы отгадали загаданное число.");
#endregion