using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atributos
{
    /*
     * Atributo personalizado con la información de los autores del desarrollo
     * 
     * AttributeUsage => Especificar donde se puede utilizar el atributo
     */


    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class DeveloperInfoAttribute : Attribute
    {

        private string programmer;
        private string revision;
        private string framework;

        public DeveloperInfoAttribute(string programmer, string revision = "1.0", string framework = "4.6.2")

        {
            this.programmer = programmer;
            this.revision = revision;
            this.framework = framework;
        }

        public string Programmer
        {
            get { return this.programmer; }
        }

        public string Revision
        {
            get { return this.revision;}
        }

        public string Framework
        {
            get { return this.framework; }
        }




    }
}
