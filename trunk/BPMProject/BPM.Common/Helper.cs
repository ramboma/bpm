using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
namespace BPM.Common
{
    public class Helper
    {
        /// <summary>
        /// 深拷贝
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object DeepClone(object obj)
        {
            BinaryFormatter bFormatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            bFormatter.Serialize(stream, obj);
            stream.Seek(0, SeekOrigin.Begin);
            return bFormatter.Deserialize(stream);
        }
    }
}
