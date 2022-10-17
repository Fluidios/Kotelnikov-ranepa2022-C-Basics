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

        public override void Execute(IRepository<Worker> repository)
        {
            if (!repository.Empty)
            {
                Log("Введите id искомого рабочего...");
                int id = int.Parse(Console.ReadLine());
                var data = repository.Get(id);
                if (!data.IsNull)
                    Log(data.Value.ToString());
            }
            else
            {
                LogError("Репозиторий пуст.");
            }
        }
    }
}
