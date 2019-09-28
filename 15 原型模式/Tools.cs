using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _15_原型模式
{
    public static class Tools
    {
        //利用 BinaryFormatter 实现深拷贝
        public static T DeepCopyByBinary<T>(this T obj)
        {
            T t = default(T);
            IFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, obj);
                ms.Seek(0, SeekOrigin.Begin);
                t = (T)formatter.Deserialize(ms);
            }
            return t;
        }

        //利用 XmlSerializer 实现深拷贝
        public static T DeepCopyByXml<T>(this T obj)
        {
            T t = default(T);
            XmlSerializer xmlserialize = new XmlSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                xmlserialize.Serialize(ms, obj);
                ms.Seek(0, SeekOrigin.Begin);
                t = (T)xmlserialize.Deserialize(ms);
            }
            return t;
        }

        //利用反射实现深拷贝
        public static T DeepCopyByReflection<T>(this T tSource)
        {
            T tResult = Activator.CreateInstance<T>();
            Type sourceType = typeof(T);
            Type resultType = typeof(T);
            var sourcePros = sourceType.GetProperties();
            foreach (var pro in sourcePros)
            {
                var sourceProValue = pro.GetValue(tSource);
                var resultPro = resultType.GetProperty(pro.Name);
                resultPro.SetValue(tResult, sourceProValue);
            }
            return tResult;
        }
    }
}
