using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12._8.Operations
{
    internal class ShowByIdOp : RepositoryOperation<Worker>
    {
        public override string OperationName => "Просмотр одной записи по id";

        public override void Execute(Repository<Worker> repository)
        {
            if (!repository.Empty)
            {
                Log("Введите id искомого рабочего...");
                Log(repository.Get(int.Parse(Console.ReadLine())).ToString());
            }
            else
            {
                LogError("Репозиторий пуст.");
            }
        }
    }
}
