using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOPRAVY.Models
{
    public partial class Producto
    {
        public int ProducId { get; set; }

        public string ProducDesc { get; set; }

        public int ProducCant { get; set; }

        public double ProducPrecio { get; set; }

        public ICollection<Encargo> Encargos { get; } = new List<Encargo>();

        public ICollection<TipoEncargo> TipoEncargos { get; } = new List<TipoEncargo>();
    }

}