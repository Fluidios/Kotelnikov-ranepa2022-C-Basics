using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12._8
{
    internal abstract class RepositoryOperation<T> where T : ISerializable<T>
    {
        public abstract string OperationName { get; }
        public abstract void Execute(Repository<T> repository);

        internal void Log(string message)
        {
            if (message == null) { LogError("Что-то пошло не так, и это все что программа может вам сказать."); return; }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
        }
        internal void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        internal void LogSuccess(string message)
        {
            if (message == null) { LogError("Что-то пошло не так, и это все что программа может вам сказать."); return; }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        internal void LogWorkersList(Worker[] list)
        {
            foreach (var item in list)
            {
                Log(item.ToString());
                Log("-------------------------------------");
            }
        }
    }
}
