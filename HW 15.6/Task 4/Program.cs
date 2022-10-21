using System.Xml.Serialization;

CreateNewPerson(out Person p);
SaveToFile(p);


string FilePath() {  return Path.Combine(Environment.CurrentDirectory, "XmlFile.xml");  }

void SaveToFile<T>(T data)
{
    using (TextWriter sw = File.CreateText(FilePath()))
    {
        XmlSerializer xs = new XmlSerializer(typeof(T));
        xs.Serialize(sw, data);
    }
}

void CreateNewPerson( out Person person)
{
    string fio = RequestString("Введите ФИО:");
    string street = RequestString("Введите название улицы:");
    int house = RequestInt("Введите номер дома:", "Номер дома не распознан.");
    int flat = RequestInt("Введите номер квартиры:", "Номер квартиры не распознан.");
    string mobileP = RequestString("Введите мобильный номер:");
    string stationaryP = RequestString("Введите домашний номер:");

    person = new Person(fio, street, house, flat, mobileP, stationaryP);
}

string RequestString (string requestString)
{
    Console.WriteLine(requestString);
    return Console.ReadLine();
}
int RequestInt(string request, string wrongReuest)
{
    int result;
    while(!TryConvertToInt(RequestString(request), wrongReuest, out result))
    {

    }
    return result;
}
bool TryConvertToInt(string source, string wrongSourceMessage, out int result)
{
    if(int.TryParse(source, out result))
        return true;
    else
    {
        Console.WriteLine(wrongSourceMessage);
        result = 0;
        return false;
    }
}

[Serializable]
public struct Person
{
    public string Fio;
    public string Street;
    public int HouseNumber;
    public int FlatNumber;
    public string MobilePhone;
    public string StationaryPhone;

    public Person(string fio, string street, int houseNumber, int flatNumber, string mobilePhone, string stationaryPhone)
    {
        Fio = fio;
        Street = street;
        HouseNumber = houseNumber;
        FlatNumber = flatNumber;
        MobilePhone = mobilePhone;
        StationaryPhone = stationaryPhone;
    }
}