using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOPRAVY.Models
{
    public partial class Conductor
    {
        public string ConCedula { get; set; }

        public string ConNombre { get; set; }

        public string ConApellido { get; set; }

        public DateTime CliFechnac { get; set; }

        public string ConNacionalidad { get; set; }

        public string ConDireccion { get; set; }

        public string ConNiveledu { get; set; }

        public string ConSexo { get; set; }

        public string ConStatus { get; set; } = null;

        public ICollection<Encargo> Encargos { get; } = new List<Encargo>();
    }

}