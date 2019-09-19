using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoEnsamblador
{
    class Program
    {
        class Customer
        {
            public int CustomerId { get; set; }
            public string Name { get; set; }

            public Customer()
            {
                CustomerId = -1;
                Name = "N/A";

            }
            public Customer(int CustomerId, string name)
            {
                this.CustomerId = CustomerId;
                this.Name = name;

            }

            public void Info()
            {
                Console.WriteLine(CustomerId + " " + Name);
            }

            public string GetFullName(string firstName, string lastName)
            {
                return firstName + " " + lastName;
            }


        }

        static void Main(string[] args)
        {
            /*
             * 
             * Uso de reflexion para trabajar con el tipo de Customer mediante 
             * System.Type
             * 
             */
            Type t = Type.GetType("TrabajoEnsamblador.Customer");

            Console.WriteLine("Nombre completo: {0}", t.FullName);
            Console.WriteLine("Nombre : {0}", t.Name);
            Console.WriteLine("Nombre : {0}", t.Namespace);
            Console.ReadKey();

            MethodInfo[] methods = t.GetMethods();
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.ReturnType.Name + " " + method.Name);
            }

            PropertyInfo[] properties = t.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine(property.PropertyType.Name + " " + property.Name);
            }

            ConstructorInfo[] constructors = t.GetConstructors();
            foreach (ConstructorInfo constructor in constructors)
            {
                Console.WriteLine(constructor.ToString());
            }

            //Ejemplo enlace temprano en reflexion

            Customer customer = new Customer();
            string fullName = customer.GetFullName("Daniel", "Arranz");
            Console.WriteLine(fullName);

            //Ejemplo enlace tardio en reflexion.No tenemos ensamblado en el proyecto.
            //Cargar el ensamblado actual (si estuviese en el tipo de datos)

            Assembly assembly = Assembly.GetExecutingAssembly();

            //Cargar la clase Customer del ensamblado
            Type customerType = assembly.GetType("TrabajoEnsamblador.Customer");

            // Crear instancia de la clase mediante constructor sin parametros utilizando
            // la clase Activator
            object customerInstance = Activator.CreateInstance(customerType);

            //Recuperar metodo de trabajo
            MethodInfo methodInfo = customerType.GetMethod("GetFullName");

            //Crear matriz para los parametros del metodo

            string[] parameters = new string[2];
            parameters[0] = "Daniel";
            parameters[1] = "Arranz";

            //Invocar metodo utilizando objeto creado y pasando la matriz de parametros
            fullName = (string)methodInfo.Invoke(customerInstance, parameters);
            Console.WriteLine("fullName");

            Console.WriteLine("\n");

            //Cargar dinamicamente ensamblado por nombre y ubicacion
            Assembly testAssemby = Assembly.LoadFile(@"c:\users\Test.dll");

            //Recuperar tipo de ensamblado 

            Type typeTest = testAssemby.GetType("Test.Maths");

            //Crear  Instancia 
            object testObject = Activator.CreateInstance(typeTest);

            //Recuperar propiedad Number (public)
            PropertyInfo propertyInfo = typeTest.GetProperty("Number");

            //Dar valor a propiedad con instancia creada
            propertyInfo.SetValue(testObject, 30.0);

            //Recuperar valor propiedad
            double value = (double)propertyInfo.GetValue(testObject);
            Console.WriteLine("Propiedad Number: {0}", value);

            //Recuperar propiedad Pi (public static)
            propertyInfo = typeTest.GetProperty("Pi");
            value = (double)propertyInfo.GetValue(null);
            Console.WriteLine("Propiedad Pi: {0}", value);

            //Ejecutar metodo Clean (public void)
            typeTest.InvokeMember("Clean", BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, null, testObject, null);

            //Ejecutar metodo DoClean (private void) con instancia
            typeTest.InvokeMember("DoClean", BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.NonPublic, null, testObject, null);

            //Ejecutar metodo Add (public double) con instancia
            double resultAdd = (double)typeTest.InvokeMember("Add", BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, null, testObject,new object[] { 20.0 });
            Console.WriteLine("Propiedad Add: {0}", resultAdd);

            //Ejecutar metodo GetPi (public static double) 
            double resultGetPi = (double)typeTest.InvokeMember("GetPi", BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.Public, null, null, null);
            Console.WriteLine("Resultado getPi: {0}", resultGetPi);

            //Recuperara valor campo number (private double)
            double resultNumber = (double)typeTest.InvokeMember("Number", BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic, null, testObject, null);
            Console.WriteLine("Resultado number: {0}", resultNumber);

        }
    }
}
