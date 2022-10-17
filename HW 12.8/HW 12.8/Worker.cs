using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HW_12._8
{
    internal class Worker
    {
        public DateTime DataCreationTime { get; }
        public string Fio { get; private set; }
        public uint Age { get; private set; }
        public uint Height { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string BirthLocation { get; private set; }

        public Worker(string fio, uint age, uint height, DateTime birthDate, string birthLocation)
        {
            Fio = fio;
            Age = age;
            Height = height;
            BirthDate = birthDate;
            BirthLocation = birthLocation;

            DataCreationTime = DateTime.Now;
        }
        private Worker(DateTime creationTime, string fio, uint age, uint height, DateTime birthDate, string birthLocation)
        {
            DataCreationTime = creationTime;
            Fio = fio;
            Age = age;
            Height = height;
            BirthDate = birthDate;
            BirthLocation = birthLocation;
        }

        public override string ToString()
        {
            return String.Format("Дата создания записи: {0}\nФИО: {1}\nВозраст: {2}\nРост: {3}\nДата рождения: {4}.{5}.{6}\nМесто рождения: {7}",
            DataCreationTime,
            Fio,
            Age,
            Height,
            BirthDate.Day,
            BirthDate.Month,
            BirthDate.Year,
            BirthLocation);
        }
    }
}
