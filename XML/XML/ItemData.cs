using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace XML
{
    /*
     * Clase del modelo(dominio) que será serializada
     */
    [Serializable]

    public class ItemData : ISerializable
    {
        #region properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }

        #endregion
        #region Constructors
        public ItemData()
        {

        }
        //para desiarilizar

        public ItemData(SerializationInfo info, StreamingContext context)
        {
            this.Id = info.GetInt32("Id");
            this.Name = info.GetString("Name");
            this.Details = info.GetString("Details");

        }

        #endregion
        //Para Serializacion
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", this.Name);
            info.AddValue("Id", this.Id);
            info.AddValue("Details", this.Details);
        }
    }
}
