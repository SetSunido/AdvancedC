using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenguaje2
{

    /*
     * Delegado para ejecución de metodos tipo void con argumento string
     */

    delegate void Consola(string texto);

    delegate bool Bulean();
    delegate bool Bulean2(int valor);

    class Program
    {
        Bulean b;
        Bulean2 b2;
        public void TestLambda(int numero)
        {
            int valorCompara = 0;
            /*
             * Expresionlabda asociada al delehado 
             */

            b = () =>
            {
                //Acceso a variables externas al lambda
                valorCompara = 10;
                return valorCompara == numero;
            };

            b2 = (v) =>
            {
                return v == valorCompara;
            };
            //Delegado SIN ejecutar
            Console.WriteLine("ValorCompara {0}", valorCompara);

            //Invocar delegado
            bool resultado = b();

            Console.WriteLine("valorCompara {0} Resultado {1}", valorCompara, resultado);

        }
        static void Main(string[] args)
        {
            // Crear delegado de tipo Consola y asociar al metodo Mostrar de esta clase
            Consola myDelegate = new Consola(Program.Mostrar);

            //Ejecución metodo asociado a delegado
            myDelegate("Uso funcional nominal asociada a delegado");

            // Crear delegado de tipo Consola y asociar al metodo anónimo
            myDelegate = delegate (string mensaje)
            {
                Console.WriteLine(mensaje);
            };
            myDelegate("Uso funcional nominal asociada a delegado");
            /****/

            Program program = new Program();

            program.TestLambda(5);

            bool resultado = program.b2(10);

            Console.WriteLine("Resultado {0}", resultado);
        }
        static void Mostrar(string mensaje)
        {
            Console.WriteLine(mensaje);
        }
    }
}
