using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOPRAVY.Models
{
    public partial class TipoSeguro
    {
        public int TsId { get; set; }

        public string TsDesc { get; set; }

        public ICollection<Camion> Camions { get; } = new List<Camion>();
    }

}