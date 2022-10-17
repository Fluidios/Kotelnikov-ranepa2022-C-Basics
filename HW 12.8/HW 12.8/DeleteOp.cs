using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12._8.Operations
{
    internal class DeleteOp : RepositoryOperation<Worker>
    {
        public override string OperationName => "Удалить запись";

        public override void Execute(IRepository<Worker> repository)
        {
            if (!repository.Empty)
            {
                Log("Введите id рабочего для удаления его данных...");
                repository.Delete(int.Parse(Console.ReadLine()));
                LogSuccess("Данные рабочего удалены из базы.");
            }
            else
            {
                LogError("Репозиторий пуст.");
            }
        }
    }
}
