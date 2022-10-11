using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12._8.Operations
{
    internal class ShowIdByFioOp : RepositoryOperation<Worker>
    {
        public override string OperationName => "Просмотр id записи по ФИО";

        public override void Execute(Repository<Worker> repository)
        {
            if (!repository.Empty)
            {
                Log("Введите ФИО искомого рабочего...");
                Log(repository.GetDataIdByRule((Worker w) => w.Fio == Console.ReadLine())[0].ToString());
            }
            else
            {
                LogError("Репозиторий пуст.");
            }
        }
    }
}
