using System;
using System.Windows;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Wpf_GandhiSayings
{
    public class MyStorage
    {
        public static void WriteXml<T>(T data, String fileName)
        {
            XmlSerializer sr = new XmlSerializer(typeof(T));
            FileStream stream;
            stream = new FileStream(fileName, FileMode.Create);
            sr.Serialize(stream, data);
            stream.Close();
        }

        public static T ReadXml<T>(string filename)
        {
            try
            {
                using (StreamReader stream = new StreamReader(filename))
                {
                    XmlSerializer sr = new XmlSerializer(typeof(T));
                    return (T)sr.Deserialize(stream);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error");
                return default(T);
            }
        }
    }
}