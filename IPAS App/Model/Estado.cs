using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IPAS_App.Model
{
    public class Estado
    {
        public string name { get; set; }
        public string abstracto { get; set; }
        public string content { get; set; }
        public string n_boton { get; set; }
    }
    [XmlRootAttribute("states")]
    public class StateCollection
    {
        [XmlElement("state")]
        public Estado[] Estados { get; set; }
    }

    
}
