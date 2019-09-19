using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrencia
{
    class Recursos
    {
        private int conexiones;

        public Recursos(int conexiones)
        {
            this.conexiones = conexiones;
        }

        public bool HacerConexion(int conexionesNecesarias)
        {
            //Comprobar que hay conexiones
            if (conexiones < 0)
            {
                throw new Exception("Conexiones no puden ser negativas");
            }
            //Comprobar que hay conexiones suficientes
            if (conexiones >= conexionesNecesarias)
            {
                Thread.Sleep(500);
                Console.WriteLine(string.Format("Conexions antes {0}"), conexiones);
                Console.WriteLine(string.Format("Estableciendo conexion"));
                conexiones -= conexionesNecesarias;
                Console.WriteLine(string.Format("Conexions antes {0}"), conexiones);

                return true;
            }
            else
            {
                Console.WriteLine("Conexiones insuficientes en recursos");
                    return false;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Recursos recursos = new Recursos(1000);

            Random random = new Random();

            //Crear 100 iteraciones y ejecutamos en paralelo (para generar tareas adicionales)
            Parallel.For(0, 100, (index) =>
            {
                //Estabelecer conexion
                recursos.HacerConexion(random.Next(1, 100));
            });

        }
    }
}
