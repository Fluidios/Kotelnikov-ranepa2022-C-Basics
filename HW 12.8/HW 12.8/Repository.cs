using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HW_12._8
{
    internal interface IRepository<T>
    {
        public bool Empty { get; }

        public RepositoryData<T>[] GetAll();
        public RepositoryData<T>[] GetAll(Predicate<T> rule);
        public int[] GetDataIdByRule(Predicate<T> rule);
        public RepositoryData<T> Get(int dataID);
        public void Add(T data);
        public void Delete(int dataID);
        public void Delete(Predicate<T> rule);
        public void ClearRepository();
    }
}
