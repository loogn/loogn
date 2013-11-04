using System;
using System.Text;
using System.Web.Script.Serialization;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;

namespace Loogn.Common
{
    public static class SerializerHelper
    {
        #region json
        static JavaScriptSerializer GetJSS()
        {
            return new JavaScriptSerializer();
        }
        public static string ToJson(object obj)
        {
            var jss = GetJSS();
            return jss.Serialize(obj);
        }
        public static void ToJson(object obj, StringBuilder output)
        {
            var jss = GetJSS();
            jss.Serialize(obj, output);
        }

        public static T JsonTo<T>(string json)
        {
            var jss = GetJSS();
            T obj = jss.Deserialize<T>(json);
            return obj;
        }
        public static object JsonTo(string json, Type targetType)
        {
            var jss = GetJSS();
            var obj = jss.Deserialize(json, targetType);
            return obj;
        }
        #endregion

        #region xml
        static XmlSerializer GetXmlSer(Type t)
        {
            return new XmlSerializer(t);
        }
        public static void ToXml(object obj, Stream stream)
        {
            var ser = GetXmlSer(obj.GetType());
            ser.Serialize(stream, obj);
        }
        public static void ToXml(object obj, TextWriter writer)
        {
            var ser = GetXmlSer(obj.GetType());
            ser.Serialize(writer, obj);
        }
        public static void ToXml(object obj, XmlWriter writer)
        {
            var ser = GetXmlSer(obj.GetType());
            ser.Serialize(writer, obj);
        }

        public static object XmlTo<T>(Stream stream) where T : class
        {
            var ser = GetXmlSer(typeof(T));
            return ser.Deserialize(stream) as T;
        }
        public static object XmlTo<T>(TextReader reader) where T : class
        {
            var ser = GetXmlSer(typeof(T));
            return ser.Deserialize(reader) as T;
        }
        public static object XmlTo<T>(XmlReader reader) where T : class
        {
            var ser = GetXmlSer(typeof(T));
            return ser.Deserialize(reader) as T;
        }
        #endregion xml

        #region binary
        static BinaryFormatter GetBinSer()
        {
            return new BinaryFormatter();
        }
        public static void ToBinary(object obj, Stream stream)
        {
            var ser = GetBinSer();
            ser.Serialize(stream, obj);
        }

        public static object BinaryTo(Stream stream)
        {
            var ser = GetBinSer();
            var obj = ser.Deserialize(stream);
            return obj;
        }
        public static T BinaryTo<T>(Stream stream) where T : class
        {
            var obj = BinaryTo(stream);
            return obj as T;
        }

        #endregion
    }
}
