using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12._8
{
    internal class RepositoryData<T>
    {
        public T Value { get; private set; }
        public bool IsNull { get; private set; }

        public RepositoryData(T data, bool createNullReport = false)
        {
            Value = data;
            IsNull = data == null || createNullReport;
        }
    }
}
