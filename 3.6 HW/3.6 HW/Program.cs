//Выполнил Котельников И.А. 05.09.2022 version 1

#region Task 1
string _fullName = "Котельников Илья Андреевич";
int _age = 22;
string _email = "i.kotelnikov@list.ru";
float _programmingPoints = 79.3f;
float _mathPoints = 76.2f;
float _physicsPoints = 60.2f;

string _outputPattern = "Ф.И.О. - {0,10}\nВозраст - {1}\nЭлектронная почта - {2}\nБаллы по программированию - {3}\nБаллы по математике - {4}\nБаллы по физике - {5}";

Console.WriteLine(_outputPattern,
    _fullName,
    _age,
    _email,
    _programmingPoints,
    _mathPoints,
    _physicsPoints
    );
#endregion

#region Task 2
float pointsSumm;
float avearagePointsValue;

pointsSumm = _programmingPoints + _mathPoints + _physicsPoints;
avearagePointsValue = pointsSumm / 3;

Console.ReadKey();
Console.WriteLine(string.Format("Сумма баллов по всем предметам - {0}", pointsSumm));
Console.ReadKey();
Console.WriteLine(string.Format("Средний балл - {0}", avearagePointsValue));
#endregion