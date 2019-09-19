using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XML
{
    /*
     *Serializador para Objetos ItemData en formato XML 
     */
    public static class Serializer
    {
        public static void Serialize(ItemData data, string path)
        {
            if (data == null)
            {
                throw new NullReferenceException("data");
            }

            //Crear serializador XML para ItemData
            XmlSerializer serializer = new XmlSerializer(data.GetType());

            //Crear fichero
            var stream = File.Create(path);

            serializer.Serialize(stream, data);

            stream.Close();
            stream.Dispose();
        }

        public static ItemData Deserialize(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }

            //Crear serializador XML para ItemData
            XmlSerializer serializer = new XmlSerializer(typeof(ItemData));

            //Crear fichero
            var stream = File.OpenRead(path);

            //Serializar Objeto en fichero
            var data = serializer.Deserialize(stream) as ItemData;

            stream.Close();
            stream.Dispose();

            return data;
        }

    }
}
