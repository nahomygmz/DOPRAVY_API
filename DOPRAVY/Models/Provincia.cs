using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOPRAVY.Models
{
    public partial class Provincia
    {
        public int ProId { get; set; }

        public string ProDesc { get; set; }

        public ICollection<Encargo> Encargos { get; } = new List<Encargo>();
    }

}