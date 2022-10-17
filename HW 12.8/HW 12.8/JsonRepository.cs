using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HW_12._8
{
    internal class JsonRepository<T> : IRepository<T>
    {
        private string _repositoryName;
        public string RepositoryPath { get; private set; }
        public bool Empty
        {
            get
            {
                return !RepositoryFileExist || !(File.ReadAllLines(RepositoryPath).Length > 0);
            }
        }
        private string TempPath
        {
            get
            {
                return Path.Combine(
                    Directory.GetCurrentDirectory(),
                    new Random().ToString() + ".json");
            }
        }
        private bool RepositoryFileExist
        {
            get
            {
                return File.Exists(RepositoryPath);
            }
        }

        public JsonRepository(string repositoryName, string specialRepositoryLocation = null)
        {
            _repositoryName = repositoryName;
            if (specialRepositoryLocation != null)
                RepositoryPath = Path.Combine(specialRepositoryLocation, repositoryName + ".json");
            else
                RepositoryPath = Path.Combine(Directory.GetCurrentDirectory(), repositoryName + ".json");
        }

        public RepositoryData<T>[] GetAll()
        {
            if (RepositoryFileExist)
            {
                List<RepositoryData<T>> dataSet = new List<RepositoryData<T>>();
                foreach (var line in File.ReadAllLines(RepositoryPath))
                {
                    dataSet.Add(new RepositoryData<T>(Deserialize(line)));
                }
                return dataSet.ToArray();
            }
            else
            {
                return new RepositoryData<T>[0];
            }
        }
        public RepositoryData<T>[] GetAll(Predicate<T> rule)
        {
            if (RepositoryFileExist)
            {
                List<RepositoryData<T>> dataSet = new List<RepositoryData<T>>();
                T data;
                foreach (var line in File.ReadAllLines(RepositoryPath))
                {
                    data = Deserialize(line);
                    if (data != null && rule(data))
                        dataSet.Add(new RepositoryData<T>(data));
                }
                return dataSet.ToArray();
            }
            else
            {
                return new RepositoryData<T>[0];
            }
        }
        public int[] GetDataIdByRule(Predicate<T> rule)
        {
            if (RepositoryFileExist)
            {
                T data; List<int> suitableDataIds = new List<int>();
                foreach (var line in File.ReadAllLines(RepositoryPath))
                {
                    data = Deserialize(line);
                    if (rule(data))
                        suitableDataIds.Add(int.Parse(line.Split('#')[0]));
                }
                return suitableDataIds.ToArray();
            }
            else
            {
                //как обрабатывать? Бросать ошибку?
                return new int[0];
            }
        }
        public RepositoryData<T> Get(int dataID)
        {
            if (RepositoryFileExist)
            {
                int id;
                foreach (var line in File.ReadAllLines(RepositoryPath))
                {
                    id = int.Parse(line.Split('#')[0]);
                    if (id == dataID)
                    {
                        return new RepositoryData<T>(Deserialize(line));
                    }
                }
                return new RepositoryData<T>(default, true);
            }
            else
            {
                return new RepositoryData<T>(default, true);
            }
        }
        public void Add(T data)
        {
            using (StreamWriter sw = RepositoryFileExist ? File.AppendText(RepositoryPath) : File.CreateText(RepositoryPath))
            {
                sw.WriteLine(SerilaizeData(data));
            }
        }
        public void Delete(int dataID)
        {
            if (RepositoryFileExist)
            {
                string tempPath = TempPath;
                var linesToKeep = File.ReadLines(RepositoryPath).Where(line => !line.Contains(dataID.ToString()));

                File.WriteAllLines(tempPath, linesToKeep);
                File.Delete(RepositoryPath);
                File.Move(tempPath, RepositoryPath);
            }
        }
        public void Delete(Predicate<T> rule)
        {
            if (RepositoryFileExist)
            {
                string tempPath = TempPath;
                var linesToKeep = File.ReadLines(RepositoryPath).Where(line => !rule(Deserialize(line)));

                File.WriteAllLines(tempPath, linesToKeep);
                File.Delete(RepositoryPath);
                File.Move(tempPath, RepositoryPath);
            }
        }
        public void ClearRepository()
        {
            File.Delete(RepositoryPath);
        }

        private string SerilaizeData(T data)
        {
            string s = JsonSerializer.Serialize(data);
            return string.Format("{0}#{1}", data.GetHashCode(), s);
        }
        private T Deserialize(string serializedData)
        {
            string serializedT = serializedData.Remove(0, serializedData.IndexOf('#') + 1);
            T data = JsonSerializer.Deserialize<T>(serializedT);
            return data;
        }
    }
}
