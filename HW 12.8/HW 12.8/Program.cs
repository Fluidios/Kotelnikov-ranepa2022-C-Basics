using HW_12._8;
using HW_12._8.Operations;

Worker w1 = new Worker("Котельников Егор Андреевич", 19, 176, new DateTime(2002, 12, 27), "город Москва");
Worker w2 = new Worker("Котельников Илья Андреевич", 22, 184, new DateTime(2000, 7, 26), "город Москва");

//repository.Add(w2);
//foreach (var item in repository.GetDataIdByRule((Worker w) => w.Fio == "Котельников Илья Андреевич"))
//{
//    Console.WriteLine(item);
//}
//foreach (var item in repository.GetAll((Worker w) => w.DataCreationTime.Hour > 13 && w.DataCreationTime.Hour < 15))
//{
//    Console.WriteLine(item.Fio);
//}
//foreach (var item in repository.GetDataIdByRule((Worker w) => w.Fio == "Котельников Илья Андреевич"))
//{
//    repository.Delete(item);
//}
//repository.Delete((Worker w) => w.Height < 180);
//repository.DeleteRepositoryFiles();

int operationCode = default;
Repository<Worker> repository = new Repository<Worker>("MyRepo");
List<RepositoryOperation<Worker>> operations = new List<RepositoryOperation<Worker>>()
{
    new ShowAllOp(),
    new ShowIdByFioOp(),
    new ShowByIdOp(),
    new CreateOp(),
    new DeleteOp(),
    new ShowInRangeOp(),
    new CloseAppOp()
};

do
{
    Console.WriteLine("Введите код желаемой операции...");
    for (int i = 0; i < operations.Count; i++)
    {
        Console.WriteLine(string.Format("{0} - {1}", i, operations[i].OperationName));
    }

    if (int.TryParse(Console.ReadLine(), out operationCode) && operationCode >= 0 && operationCode < operations.Count)
    {
        operations[operationCode].Execute(repository);
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Код операции не распознан или не является валидным!");
        Console.ForegroundColor = ConsoleColor.White;
    }
} while (operationCode != operations.Count-1);