using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenguaje
{

    public class Orden
    {
        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Amount { get; set; }

        private int[] Month = new int[12] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        private string[] Currencies = new string[4] { "EUR", "USD", "GBP", "JPN" };

        #region Indexers
        public string this[int index]

        {
            get
            {
                if (index < 0 || index > Currencies.Length - 1)
                {
                    throw new ArgumentOutOfRangeException("Not valid Index");
                }
                return Currencies[index];
            }

        }
        public int this[string name]
        {
            get
            {
                if (name.Equals("Daniel"))
                {
                    return 1;
                }
                else if (name.Equals("Elena"))
                {
                    return 2;
                }
                return -1;
            }
            set
            {
                OrderId = value;
            }
        }
        #endregion

        #region "Constructors"
        public Orden()
        {

        }

        public Orden(decimal Amount) { this.Amount = Amount; }

        public Orden(int OrderId) { this.OrderId = OrderId; }


        #endregion

        #region "Overrides"

        public override string ToString()
        {
            return "orden" + OrderId + "Cantidad" + Amount;
        }
        #endregion

        #region "Operands Overrides"

        public static Orden operator ++(Orden orden)
        {
            return new Orden(orden.OrderId + 1);
        }

        #endregion

        #region "Conversions"

        public static implicit operator int(Orden orden)
        {
            return orden.OrderId;
        }

        public static explicit operator string(Orden orden)
        {
            return orden.FirstName + "" + orden.LastName;
        }

        #endregion

                    /*
            * Tipos anónimos => Tipos sin nombre. Solo llevan propiedades
            * de solo lectura
            * 
            * new + incializador de objeto
            * 
            * Nombre creado por CLR no disponible por codigo
            * 
            */


            //        var pedido = new { Pais = "España", Ciudad = "Madrid", Codigo = 34 };

              //      Console.WriteLine(Pais{0}, pedido.Pais);
 
    }

    class Program
    {

        static void Main(string[] args)
        {
            Orden orden = new Orden();
            Console.WriteLine("Currency 2: {0}", orden[1]);

            orden["Sergio"] = 101;
            Console.WriteLine("Codigo Daniel: {0}", orden["Daniel"]);

            Orden orden1 = new Orden(101);
            Console.WriteLine(orden1);

            //Incrementar en 1 el OrderId del objeto
            orden1++;
            Orden orden2 = new Orden(2000M);
            Orden orden3 = new Orden(3000M);

            int codigo = orden1;
            Console.WriteLine("Codigo {0}", codigo);

            Orden orden4 = new Orden
            {
                FirstName = "Daniel",
                LastName = "Arranz"
            };

            string fullname = (string)orden4;

            Console.WriteLine("Cliente {0}", fullname);
            Console.ReadKey();

            string cadena = "Programación C# framework VS";
            Console.WriteLine("Cliente {0}", cadena);

            cadena = cadena.Capitalize();

            Console.WriteLine("Cadena Mays {0}", cadena);
        }
    }

   



    /*
     * Partir de clase publica y estatica para crear metodos de extension
     */
     public static class StringExtension
    {
        /*
         * Metodo de extension publico y estatico
         *
         *
         *this string -> Se crea el metodo para el tipo string 
         */
         public static string Capitalize(this string cadena)
        {
            string[] palabras = cadena.Split(' ');
            for(int i = 0; i < palabras.Length; i++)
            {
                palabras[i] = string.Concat(palabras[i].Substring(0, 1).ToUpper(), palabras[i].Substring(1).ToLower());
            }

            StringBuilder builder = new StringBuilder();

            foreach (string palabra in palabras)
            {
                builder.Append(palabra + "");
            }
            return builder.ToString();
            
        }

    }


   
}
