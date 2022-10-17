using HW_12._8;
using HW_12._8.Operations;

int operationCode = default;
IRepository<Worker> repository = new JsonRepository<Worker>("MyRepo");
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