using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOPRAVY.Models
{
    public class Cliente
    {
        public string CliCedula { get; set; }

        public string CliNombre { get; set; }

        public string CliApellido { get; set; }

        public DateTime CliFechnac { get; set; }

        public string CliSexo { get; set; }

        public string CliStatus { get; set; }

        public string CliPw { get; set; }

        public ICollection<Encargo> Encargos { get; } = new List<Encargo>();
    }
}