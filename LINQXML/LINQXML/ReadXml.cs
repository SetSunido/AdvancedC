using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace LINQXML
{
    //Leer XML utilizando LINQ a XML mediante Xelement
    public class ReadXml
    {
        public static void ReadFromXml()
        {
            //Cargar XML en elemento
            XElement xElement = XElement.Load("Employees.xml");

            //Recuperar todos los elementos del XML
            var elements = xElement.Elements();

            //Leer XML Compleoto
            foreach (var element in elements)
            {
                Console.WriteLine(element);
                Console.ReadKey();
            }
        }
        public static void AlternateReadFromXml()
        {
            //Cargar XML en elemento
            XDocument xDocument = XDocument.Load("Employees.xml");

            //Recuperar todos los elementos del XML XDocument
            var elements = xDocument.Elements();

            //Leer XML Completo
            foreach (var element in elements)
            {
                Console.WriteLine(element);
                Console.ReadKey();
            }
        }
        public static void ListSingleElement()
        {
            //Cargar XML en elemento
            XElement xmlNames = XElement.Load("Employees.xml");

            //Recuperar todos los elementos del XML
            var employees = xmlNames.Elements();

            Console.WriteLine("Listado nombres Empleados");

            //Leer XML Completo
            foreach (var employee in employees)
            {
                ///Acceder elemento <name> de <employee>
                Console.WriteLine(employee.Element("name").Value);
                Console.WriteLine("Empleado {0} con ID{1}",
                employee.Element("name").Value,
                employee.Element("empid").Value);
                Console.ReadKey();

            }
        }
        public static void ListOnlyMales()
        {
            //Cargar XML en elemento
            XElement xmlGender = XElement.Load("Employees.xml");

            //Recuperar todos los elementos del XML que son varones
            var employees = xmlGender.Elements("employee").Where(emp => (string)emp.Element("Gender") == "Male").ToList();

            //basadao en consulta

            //var employees = (from emp in xmlGender.Elements("employee")
            //                 where (string)emp.Element("Gender") == "Male"
            //                 select emp).ToList();

            Console.WriteLine("Listado nombres Empleados varones");

            //Leer XML Completo
            foreach (var employee in employees)
            {
                ///Acceder elemento <name> de <employee>
                Console.WriteLine(employee.Element("name").Value);
                Console.ReadKey();

            }
        }
        public static void ListOnlyMadridInhabitants()
        {
            //Cargar XML en elemento
            XElement xmlCity = XElement.Load("Employees.xml");

            //Recuperar todos los elementos del XML que son varones
            var employees = xmlCity.Elements("employee").Where(emp => (string)emp.Element("city") == "Madrid").ToList();

            //basadao en consulta
                        
            Console.WriteLine("Listado Empleados viviendo en Madrid");

            //Leer XML Completo
            foreach (var employee in employees)
            {
                ///Acceder elemento <name> de <employee>
                Console.WriteLine(employee);
                Console.ReadKey();

            }
        }
        
    }
}
