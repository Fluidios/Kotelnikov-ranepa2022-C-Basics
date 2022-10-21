using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

CreateNewPerson(out Person p);
SaveToFile(p);


string FilePath() {  return Path.Combine(Environment.CurrentDirectory, "XmlFile.xml");  }

void SaveToFile(Person data)
{
    using(StreamWriter sw = File.CreateText(FilePath()))
    {
        XElement root = new XElement(data.Fio);
        root.Add(ToXElement(data.Address));
        root.Add(ToXElement(data.Phones));
        root.Save(sw);
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

XElement ToXElement<T>(T data)
{

    using (var memoryStream = new MemoryStream())
    {
        using (TextWriter streamWriter = new StreamWriter(memoryStream))
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            xmlSerializer.Serialize(streamWriter, data);
            return XElement.Parse(Encoding.ASCII.GetString(memoryStream.ToArray()));
        }
    }
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
    public AddressContainer Address;
    public PhonesContainer Phones;

    public Person(string fio, string street, int houseNumber, int flatNumber, string mobilePhone, string stationaryPhone)
    {
        Fio = fio;
        Address = new AddressContainer(street, houseNumber, flatNumber);
        Phones = new PhonesContainer(mobilePhone, stationaryPhone);
    }

    [Serializable]
    public struct AddressContainer
    {
        public string Street;
        public int HouseNumber;
        public int FlatNumber;

        public AddressContainer(string street, int houseNumber, int flatNumber)
        {
            Street = street;
            HouseNumber = houseNumber;
            FlatNumber = flatNumber;
        }
    }
    [Serializable]
    public struct PhonesContainer
    {
        public string MobilePhone;
        public string StationaryPhone;

        public PhonesContainer(string mobilePhone, string stationaryPhone)
        {
            MobilePhone = mobilePhone;
            StationaryPhone = stationaryPhone;
        }
    }
}