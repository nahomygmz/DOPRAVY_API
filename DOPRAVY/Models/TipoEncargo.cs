using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOPRAVY.Models
{
    public partial class TipoEncargo
    {
        public int TeId { get; set; }

        public string TeDesc { get; set; }

        public int TeIdproduc { get; set; }

        public ICollection<Encargo> Encargos { get; } = new List<Encargo>();

    }

}