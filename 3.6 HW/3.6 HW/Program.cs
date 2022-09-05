//Выполнил Котельников И.А. 05.09.2022 version 1

#region Task 1
string _fullName = "Котельников Илья Андреевич";
int _age = 22;
string _email = "i.kotelnikov@list.ru";
float _programmingPoints = 79.3f;
float _mathPoints = 76.2f;
float _physicsPoints = 60.2f;

Console.WriteLine(string.Format("Ф.И.О. - {0}", _fullName));
Console.WriteLine(string.Format("Возраст - {0}", _age));
Console.WriteLine(string.Format("Электронная почта - {0}", _email));
Console.WriteLine(string.Format("Баллы по программированию - {0}", _programmingPoints));
Console.WriteLine(string.Format("Баллы по математике - {0}", _mathPoints));
Console.WriteLine(string.Format("Баллы по физике - {0}", _physicsPoints));
#endregion

#region Task 2
float pointsSumm;
float avearagePointsValue;

pointsSumm = _programmingPoints + _mathPoints + _physicsPoints;
avearagePointsValue = pointsSumm / 3;

Console.ReadLine();
Console.WriteLine(string.Format("Сумма баллов по всем предметам - {0}", pointsSumm));
Console.ReadLine();
Console.WriteLine(string.Format("Средний балл - {0}", avearagePointsValue));
#endregion