
Dictionary<string, string> phoneBook = new Dictionary<string, string>();
for (int i = 0; i < 3; i++)
{
    AddNewPhone(phoneBook);
}

Console.WriteLine("Введите телефон, чтобы найти его владельца:");
string request = Console.ReadLine();
string report = GetPhoneOwnerFIO(phoneBook, request);
if (report.Length < 1)
    Console.WriteLine("Телефонная книга не содержит информации о владельце этого номера.");
else
    Console.WriteLine(string.Format("Владелец номера {0} - {1}", request, report));

void AddNewPhone(Dictionary<string, string> phoneBook)
{
    Console.WriteLine("Введите ФИО:");
    string fio = Console.ReadLine();

    Console.WriteLine("Введите номера телефонов, принадлежащих этому человеку. Для прекращения ввода нажмите Enter...");
    string phone;
    do
    {
        phone = Console.ReadLine();
        if (phoneBook.ContainsKey(phone))
        {
            phoneBook[phone] = fio;
            Console.WriteLine("Найден совпадающий номер телефона, ФИО владельца было обновлено.");
        }
        else if(phone.Length > 0)
            phoneBook.Add(phone, fio);

    } while (phone.Length > 0);
}
string GetPhoneOwnerFIO(Dictionary<string, string> phoneBook, string phone)
{
    if (phoneBook.TryGetValue(phone, out string owner))
        return owner;
    else
        return string.Empty;
}