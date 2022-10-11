using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12._8
{
    internal interface ISerializable<T>
    {
        public string Serialize();
        public static T Deserialize(string serializedData) { return default; }
    }
}
