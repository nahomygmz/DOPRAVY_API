using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOPRAVY.Models
{
    public partial class Sexo
    {
        public string SexoDesc { get; set; }

        public ICollection<Cliente> Clientes { get; } = new List<Cliente>();

        public ICollection<Conductor> Conductors { get; } = new List<Conductor>();
    }

}