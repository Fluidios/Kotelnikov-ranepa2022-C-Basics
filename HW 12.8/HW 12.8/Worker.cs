using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HW_12._8
{
    internal struct Worker: ISerializable<Worker>
    {
        public DateTime DataCreationTime { get; }
        public string Fio { get; private set; }
        public uint Age { get; private set; }
        public uint Height { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string BirthLocation { get; private set; }

        public Worker(string fio, uint age, uint height, DateTime birthDate, string birthLocation) : this()
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
        public string Serialize()
        {
            return string.Format("{0} {1}#{2}#{3}#{4}#{5}#{6}", 
                DataCreationTime.ToShortDateString(),
                DataCreationTime.ToShortTimeString(),
                Fio,
                Age, 
                Height, 
                BirthDate.ToShortDateString(),
                BirthLocation
                );
        }

        public static Worker Deserialize(string serializedWorkerData)
        {
            string[] parametrs = serializedWorkerData.Split('#');
            string[] creationTime = parametrs[0].Split('.', ' ', ':');
            string[] birthDate = parametrs[4].Split('.');
            Worker worker = new Worker
                (
                new DateTime(int.Parse(creationTime[2]), int.Parse(creationTime[1]), int.Parse(creationTime[0]), int.Parse(creationTime[3]), int.Parse(creationTime[4]), 0),
                parametrs[1],
                uint.Parse(parametrs[2]),
                uint.Parse(parametrs[3]),
                new DateTime(int.Parse(birthDate[2]), int.Parse(birthDate[1]), int.Parse(birthDate[0])),
                parametrs[5]
                );
            return worker;
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
