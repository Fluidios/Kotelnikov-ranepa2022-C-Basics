using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12._8.Operations
{
    internal class ShowInRangeOp : RepositoryOperation<Worker>
    {
        public override string OperationName => "Просмотр записей в выбранном диапазоне дат";

        public override void Execute(IRepository<Worker> repository)
        {
            if (!repository.Empty)
            {
                Log("Введите дату начала выборки в формате день.месяц.год...");
                string[] s = Console.ReadLine().Split('.');
                DateTime from = new DateTime(int.Parse(s[2]), int.Parse(s[1]), int.Parse(s[0]));

                Log("Введите дату конца выборки в формате день.месяц.год...");
                s = Console.ReadLine().Split('.');
                DateTime to = new DateTime(int.Parse(s[2]), int.Parse(s[1]), int.Parse(s[0]));

                var searchResult = repository.GetAll((Worker w) =>
                (
                    w.DataCreationTime.Subtract(from).Days > 0 &&
                    w.DataCreationTime.Subtract(to).Days < 0
                ));

                if (searchResult.Length > 0)
                {
                    LogWorkersList(searchResult);
                }
                else
                {
                    Log("В указанном диапазон записей создано не было.");
                }
            }
            else
            {
                LogError("Репозиторий пуст.");
            }
        }
    }
}
