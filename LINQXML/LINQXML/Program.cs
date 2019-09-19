using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Espacio de nombres para LINQ a XML
using System.Xml.Linq;

namespace LINQXML
{
    class Program
    {
        static void Main(string[] args)
        {
            //ReadXml.ReadFromXml();
            //ReadXml.AlternateReadFromXml();
            //ReadXml.ListSingleElement();
            //ReadXml.ListOnlyMales();
            ReadXml.ListOnlyMadridInhabitants();
            Console.ReadKey();

        }
    }
}
