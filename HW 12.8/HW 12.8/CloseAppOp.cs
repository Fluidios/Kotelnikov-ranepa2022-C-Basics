using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12._8.Operations
{
    internal class CloseAppOp : RepositoryOperation<Worker>
    {
        public override string OperationName => "Закрыть программу";

        public override void Execute(IRepository<Worker> repository)
        {
            Log("Завершение программы...");
        }
    }
}
