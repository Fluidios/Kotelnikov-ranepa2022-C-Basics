int operationCode  = default;

do
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Введите код желаемой операции...\n1 - Вывести данные на экран.\n2 - Создать новую запись и добавить ее в БД.\n3 - Закрыть программу.");
    if(int.TryParse(Console.ReadLine(), out operationCode) && operationCode > 0 && operationCode < 4)
    {
        switch (operationCode)
        {
            case 1:
                ShowFileContent();
                break;
            case 2:
                AddToFile(CreateNewPersonalData());
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(String.Format("Данные сохранены в файл {0}", GetFilePath()));
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 3:
                Console.WriteLine("Завершение программы...");
                break;
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Код операции не распознан или не является валидным!");
    }
} while (operationCode != 3);

void ShowFileContent()
{
    if (FileExist())
    {
        foreach (var line in File.ReadAllLines(GetFilePath()))
        {
            Console.WriteLine(PersonalData.Deserialize(line).ToString());
            Console.WriteLine("-----------------------------------------------");
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Файл не существует, добавьте хотя бы одну запись.");
        Console.ForegroundColor = ConsoleColor.White;
    }
}

PersonalData CreateNewPersonalData()
{
    Console.WriteLine("Введите ID: ");
    int id;
    while(!int.TryParse(Console.ReadLine(), out id))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Не удалось распознать id, id должно быть представлено целым числом!");
        Console.ForegroundColor = ConsoleColor.White;
    }

    DateTime lastUpdateTime = DateTime.Now;

    Console.WriteLine("Введите ФИО через пробел: ");
    string[] fio = Console.ReadLine().Split(" ");
    while (fio.Length != 3)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Количество параметров в ФИО должно быть равно 3!");
        Console.ForegroundColor = ConsoleColor.White;
        fio = Console.ReadLine().Split(" ");
    }

    Console.WriteLine("Введите возрст: ");
    int age;
    while (!int.TryParse(Console.ReadLine(), out age) || age <= 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Не удалось распознать возраст, возраст должен быть представлен целым числом и быть больше 0!");
        Console.ForegroundColor = ConsoleColor.White;
    }

    Console.WriteLine("Введите рост: ");
    int height;
    while (!int.TryParse(Console.ReadLine(), out height) || height <= 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Не удалось распознать рост, рост должен быть представлен целым числом и быть больше 0!");
        Console.ForegroundColor = ConsoleColor.White;
    }

    DateTime birthDate = new DateTime(DateTime.Now.Year - age, DateTime.Now.Month, DateTime.Now.Day);

    Console.WriteLine("Введите место рождения: ");
    string birthLocation = Console.ReadLine();

    return new PersonalData(id, lastUpdateTime, fio, age, height, birthDate, birthLocation);
}

void AddToFile(PersonalData data)
{
    if (FileExist())
    {
        using (StreamWriter sw = File.AppendText(GetFilePath()))
        {
            sw.WriteLine(data.Serialize());
        }
    }
    else
    {
        using (StreamWriter sw = File.CreateText(GetFilePath()))
        {
            sw.WriteLine(data.Serialize());
        }
    }
}

string GetFilePath()
{
     return Path.Combine(Directory.GetCurrentDirectory(), "db.txt");
}
bool FileExist()
{
    return File.Exists(GetFilePath());
}

class PersonalData
{
    public int ID { get; private set; }
    public DateTime LastUpdateTime { get; private set; }
    public string[] FIO { get; private set; }
    public int Age { get; private set; }
    public int Height { get; private set; }
    public DateTime BirthDate { get; private set; }
    public string BirthLocation { get; private set; }

    public PersonalData(int iD, DateTime lastUpdateTime, string[] fIO, int age, int height, DateTime birthDate, string birthLocation)
    {
        ID = iD;
        LastUpdateTime = lastUpdateTime;
        FIO = fIO;
        Age = age;
        Height = height;
        BirthDate = birthDate;
        BirthLocation = birthLocation;
    }

    public string Serialize()
    {
        string result = ID.ToString();
        result += String.Format("#{0}.{1}.{2} {3}:{4}", LastUpdateTime.Day, LastUpdateTime.Month, LastUpdateTime.Year, LastUpdateTime.Hour, LastUpdateTime.Minute);
        result += String.Format("#{0} {1} {2}", FIO[0], FIO[1], FIO[2]);
        result += String.Format("#{0}", Age);
        result += String.Format("#{0}", Height);
        result += String.Format("#{0}.{1}.{2}", BirthDate.Day, BirthDate.Month, BirthDate.Year);
        result += String.Format("#{0}", BirthLocation);
        return result;
    }
    public static PersonalData Deserialize(string serializedData)
    {
        string[] strings = serializedData.Split("#");
        int[] lastUpdate = Array.ConvertAll(strings[1].Split(new char[] { '.', ':', ' ' }), s => int.Parse(s));
        string[] fio = strings[2].Split(" ");
        int[] birthDate = Array.ConvertAll(strings[5].Split("."), s => int.Parse(s));
        return new PersonalData
            (
            int.Parse(strings[0]),
            new DateTime(lastUpdate[2], lastUpdate[1], lastUpdate[0], lastUpdate[3], lastUpdate[4], 0),
            fio,
            int.Parse(strings[3]),
            int.Parse(strings[4]),
            new DateTime(birthDate[2], birthDate[1], birthDate[0]),
            strings[6]
            );
    }

    public override string ToString()
    {
        return String.Format("ID: {0}\nПоследнее обновление: {1}\nФИО: {2}\nВозраст: {3}\nРост: {4}\nДата рождения: {5}.{6}.{7}\nМесто рождения: {8}",
            ID,
            LastUpdateTime,
            FIO[0] + " " + FIO[1] + " " + FIO[2],
            Age,
            Height,
            BirthDate.Day,
            BirthDate.Month,
            BirthDate.Year,
            BirthLocation);
    }
}