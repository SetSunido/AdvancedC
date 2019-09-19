using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Atributos
{
    class Program
    {
        static void Main(string[] args)
        {
            //Reuperara Type de Encryptor
            Type type = typeof(Encryptor);

            // Recuperar por reflexión atributo personalizado DeveloperInfoAttribute

            var typeAttribute = type.GetCustomAttribute<DeveloperInfoAttribute>();

            Console.WriteLine(FormatComment(typeAttribute, type.Name, "Type"));

            //Iterar por los atributos recuperados
            foreach(var member in type.GetMembers())
            {
                var memberAttribute = member.GetCustomAttributes<DeveloperInfoAttribute>();

                foreach (var attribute in memberAttribute)
                {
                    Console.WriteLine(FormatComment(attribute, member.Name, member.MemberType.ToString()));
                    Console.ReadKey();
                }
            }
        }

        private static string FormatComment(DeveloperInfoAttribute attribute, string element, string type)
        {
            if (attribute==null)
            {
                return string.Format("{0}:{1} No tiene atributo DeveloperInfo", type, element);
            }
            return string.Format("{0}:{1} Programador, {2}  Version, {3} Framework {4}",
            type,element, attribute.Programmer, attribute.Revision, attribute.Framework);
        }
    }
}
