using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12._8.Operations
{
    internal class CreateOp : RepositoryOperation<Worker>
    {
        public override string OperationName => "Создать запись";

        public override void Execute(Repository<Worker> repository)
        {
            Log("Следуйте инструкции...");
            repository.Add(CreateWorker());
            LogSuccess("Данные рабочего внесены в базу.");
        }
        Worker CreateWorker()
        {
            Console.WriteLine("Введите ФИО через пробел: ");
            string fio = Console.ReadLine();

            Console.WriteLine("Введите возрст: ");
            uint age;
            while (!uint.TryParse(Console.ReadLine(), out age))
            {
                LogError("Не удалось распознать возраст, возраст должен быть представлен целым числом и быть больше 0!");
            }

            Console.WriteLine("Введите рост: ");
            uint height;
            while (!uint.TryParse(Console.ReadLine(), out height))
            {
                LogError("Не удалось распознать рост, рост должен быть представлен целым числом и быть больше 0!");
            }

            DateTime birthDate = new DateTime(DateTime.Now.Year - (int)age, DateTime.Now.Month, DateTime.Now.Day);

            Console.WriteLine("Введите место рождения: ");
            string birthLocation = Console.ReadLine();

            return new Worker(fio, age, height, birthDate, birthLocation);
        }
    }
}
