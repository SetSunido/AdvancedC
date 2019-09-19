using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Maths
    {
        public Maths()
        {
            Console.WriteLine("Constructor predet. de Maths");


        }

        private double number = 100;

        public double Number { get; set; }

        public void Clean()
        {
            Console.WriteLine("Metodo Clean Maths");

        }

        private void DoClean()
        {
            Console.WriteLine("Metodo DoClean Maths");

        }

        public double Add(double num)
        {
            return num + number;
        }

        public static double Pi
        {
            get
            {
                return 3.1415;
            }
        }

        public static double GetPi()
        {
            return Pi;
        }
    }
}
