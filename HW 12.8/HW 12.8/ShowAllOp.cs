using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12._8.Operations
{
    internal class ShowAllOp : RepositoryOperation<Worker>
    {
        public override string OperationName => "Просмотреть все записи";

        public override void Execute(Repository<Worker> repository)
        {
            if (!repository.Empty)
                LogWorkersList(repository.GetAll());
            else
                LogError("Репозиторий пуст.");
        }
    }
}
