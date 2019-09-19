using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atributos
{
    [DeveloperInfo("Daniel Arranz")]

    public class Encryptor
    {
        private byte[] _salt;

        public Encryptor(byte[] salt)
        {
            this._salt = salt;
        }

        [DeveloperInfo("Daniel Arranz")]
        [DeveloperInfo("Elena Arranz", "2.0")]

        public byte[] Encript(string text)
        {
            return null;
        }

        [DeveloperInfo("Daniel Arranz")]
        [DeveloperInfo("Elena Arranz", "2.0")]
        [DeveloperInfo("Sergio Arranz", "2.0", "4.7.1")]


        public byte[] Decript(byte[] text)
        {
            return null;
        }
    }
}
