using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HW_12._8
{
    internal class Repository<T> where T : ISerializable<T>
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
                    new Random().ToString() + ".txt"); 
            } 
        }
        private bool RepositoryFileExist 
        { 
            get 
            {
                return File.Exists(RepositoryPath); 
            } 
        }

        public static Repository<T> ConnectTo(string repositoryName, string specialRepositoryLocation = null)
        {
            //на будущее
            Repository<T> repository = new Repository<T>(repositoryName, specialRepositoryLocation);
            if (repository.RepositoryFileExist)
                return repository;
            else
                return null;
        }

        public Repository(string repositoryName, string specialRepositoryLocation = null)
        {
            _repositoryName = repositoryName;
            if (specialRepositoryLocation != null)
                RepositoryPath = Path.Combine(specialRepositoryLocation, repositoryName + ".txt");
            else
                RepositoryPath = Path.Combine(Directory.GetCurrentDirectory(), repositoryName + ".txt");
        }

        public T[] GetAll()
        {
            //Как упростить конструкцию? Она повторяется, но тело разное.
            if (RepositoryFileExist)
            {
                List<T> dataSet = new List<T>();
                foreach (var line in File.ReadAllLines(RepositoryPath))
                {
                    dataSet.Add(Deserialize(line));
                }
                return dataSet.ToArray();
            }
            else
            {
                return default;
            }
        }
        public T[] GetAll(Predicate<T> rule)
        {
            if (RepositoryFileExist)
            {
                List<T> dataSet = new List<T>();
                T data;
                foreach (var line in File.ReadAllLines(RepositoryPath))
                {
                    data = Deserialize(line);
                    if(rule(data))
                        dataSet.Add(data);
                }
                return dataSet.ToArray();
            }
            else
            {
                return default;
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
                return default;
            }
        }
        public T Get(int dataID)
        {
            if (RepositoryFileExist)
            {
                int id;
                foreach (var line in File.ReadAllLines(RepositoryPath))
                {
                    id = int.Parse(line.Split('#')[0]);
                    if (id == dataID)
                    {
                        return Deserialize(line);
                    }
                }
                return default;
            }
            else
            {
                return default;
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
        
        public void DeleteRepositoryFiles()
        {
            File.Delete(RepositoryPath);
        }

        private string SerilaizeData(T data)
        {
            string s = data.Serialize();
            return string.Format("{0}#{1}", data.GetHashCode(), s);
        }
        private T Deserialize(string serializedData)
        {
            string serializedT = serializedData.Remove(0, serializedData.IndexOf('#')+1);
            return (T) typeof(T).GetMethod("Deserialize").Invoke(null, new object[1] { serializedT});
        }
    }
}
