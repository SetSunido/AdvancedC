using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XML;

namespace XML
{


    class Program
    {
        private string url = "Libros.xml";

        private string divisas = @"http://www.ecb.int/stats/eurofxref/eurofxref-daily.xml";

        private string noticias = @"http://rss.cnn.com/rss/edition_world.rss";

        private void LectorTextoXML()
        {
            // Crear lector XML texto solo
            XmlTextReader reader = new XmlTextReader(url);

            //Leer xml en memoria mientras haya nodos
            while (reader.Read())
            {
                //Comprobar tipo de nodo
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // Elemento
                        Console.Write("<" + reader.Name);
                        //Procesar los atributos del elemento
                        while (reader.MoveToNextAttribute())
                        {
                            Console.Write("" + reader.Name + "=" + reader.Value + "'");
                        }

                        Console.WriteLine(">");
                        break;
                    case XmlNodeType.Text: // Texto Elemento
                        {
                            Console.WriteLine(reader.Value);
                            break;
                        }
                    case XmlNodeType.EndElement: // Final Elemento
                        {
                            Console.WriteLine("</" + reader.Name);
                            Console.WriteLine(">");
                            break;
                        }

                }
            }

        }

        private void LectorXML()
        {
            //Crear lector XML forward
            XmlReader reader = XmlReader.Create(divisas);

            //Leer XML en memoria mientras haya nodos
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Cube")
                {
                    if (reader.HasAttributes)
                    {
                        Console.WriteLine(reader.GetAttribute("currency") + ":" + reader.GetAttribute("rate"));
                    }
                }
            }

        }

        private void LectorDocumentoXML()
        {
            //Crear lector XML
            XmlDocument document = new XmlDocument();

            //Cargar datos en documento
            document.Load(divisas);

            //Procesar elementos Cube por el arbol DOM
            /* foreach (XmlNode nodo in document.DocumentElement.ChildNodes[2].ChildNodes[0].ChildNodes)
             {
                 Console.WriteLine(nodo.Attributes["currency"] + ":" + nodo.Attributes["rate"]);

             }*/

            //Manera alternativa a la de arriba
            foreach (XmlNode nodo in document.DocumentElement.GetElementsByTagName("Cube"))
            {
                Console.WriteLine(nodo.Attributes["currency"] + ":" + nodo.Attributes["rate"]);

            }
        }

        private void LectorDocumentoXMLXpath()
        {
            //Crear lector XML
            XmlDocument document = new XmlDocument();

            //Cargar datos en documento
            document.Load(noticias);

            // Recuperar un elemento
            XmlNode titleNode = document.SelectSingleNode("//rss/channel/title");

            if (titleNode != null)
            {
                Console.WriteLine(titleNode.InnerText);
            }
            //Recuperar lista de nodos
            XmlNodeList itemNodes = document.SelectNodes("//rss/channel/item");

            foreach (XmlNode node in itemNodes)
            {
                titleNode = node.SelectSingleNode("title");
                XmlNode datenode = node.SelectSingleNode("pubDate");
                if (titleNode != null && datenode != null)
                {
                    Console.WriteLine(titleNode.InnerText + " : " + datenode.InnerText);
                }
            }

        }

        private void EscritorXML()
        {
            XmlWriter writer = XmlWriter.Create("Data.xml");

            //Crear documento XML
            writer.WriteStartDocument();

            //Crear elemento raiz
            writer.WriteStartElement("usuarios");
            writer.WriteStartElement("usuario");
            writer.WriteAttributeString("edad", "34");
            writer.WriteString("Daniel Sanz");
            writer.WriteEndElement();
            writer.WriteStartElement("usuario");
            writer.WriteAttributeString("edad", "26");
            writer.WriteString("Elena Abad");
            writer.WriteEndElement();

            //Cerrar Documento
            writer.WriteEndDocument();
            writer.Close();
            Console.WriteLine("Generado el fichero XML");


        }

        private void EscritorDocumentoXML()
        {
            XmlDocument document = new XmlDocument();

            //Crear declaracion XML

            XmlNode xmldeclaration = document.CreateXmlDeclaration("1.0", "utf-8", "yes");

            //Agregar al final del documento
            document.AppendChild(xmldeclaration);

            //Crear elemento raiz
            XmlNode rootNode = document.CreateElement("usuarios");
            document.AppendChild(rootNode);
            XmlNode userNode = document.CreateElement("usuario");
            XmlAttribute attribute = document.CreateAttribute("edad");
            attribute.Value = "34";
            userNode.Attributes.Append(attribute);

            document.Save("data-doc.xml");
                                 
            Console.WriteLine("Generado el fichero XML");


        }
        private void Marshall()
        {
            var data = new ItemData
            {
                Id = 102,
                Name = "Finanzas",
                Details = "Departamento Cuentas Madrid"
            };

            var path = "ItemData.xml";
            Serializer.Serialize(data, path);

            Console.WriteLine("Seralizado objeto en fichero XML");
        }

        private void Unmarshall()
        {
            var path = "ItemData.xml";
            var data = Serializer.Deserialize(path);
            Console.WriteLine("{0} {1} {2}", data.Id, data.Name, data.Details);
            Console.WriteLine("Deseralizado objeto en fichero XML");
        }


        static void Main(string[] args)
        {
            Program program = new Program();
            {
                //program.LectorTextoXML();
                //program.LectorXML();
                //program.LectorDocumentoXML();
                //Crear documento XML
                XmlDocument document = new XmlDocument();

                ////Cargar datos texto XML en documento
                //document.LoadXml("<usuarios><usuario nombre='JRS'>QA</usuario></usuarios>");
                ////recuperar el nombre del elemento
                //Console.WriteLine("Elemento: {0}", document.DocumentElement.Name);
                ////recuperar contenido texto elemento
                //Console.WriteLine("Texto: {0}", document.DocumentElement.InnerText);
                ////recuperar contenido XML elemento
                //Console.WriteLine("Texto: {0}", document.DocumentElement.InnerXml);
                ////recuperar contenido XML elemento (incluido el mismo)
                //Console.WriteLine("Texto: {0}", document.DocumentElement.OuterXml);
                //program.LectorDocumentoXMLXpath();
                //program.EscritorXML();
                //program.EscritorDocumentoXML();
                program.Marshall();
                program.Unmarshall();
        

                Console.ReadKey();
            }

        }
    }


}
