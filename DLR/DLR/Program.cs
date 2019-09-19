using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLR
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Data> datosWord = new List<Data>
            {
                new Data {Title = "DLR", Details = "Dynamic Langauge Runtime"},
                new Data {Title = "Dynamic", Details = "objetos dinámicos no administrados"},
            };

            WordDinamico word = new WordDinamico(datosWord);

            word.WriteToWordDocument();

            Console.WriteLine("Generando fichero {0}", word.output);

        }
    }
}
