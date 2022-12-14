using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOPRAVY.Models
{
    public partial class Camion
    {
        public string CamUnidad { get; set; }

        public string CamMarca { get; set; }

        public string CamModelo { get; set; }

        public string CamColor { get; set; }

        public string CamPlaca { get; set; }

        public string CamChasis { get; set; }

        public string CamTipovehiculo { get; set; }

        public string CamTiposeguroid { get; set; }

        public string CamStatus { get; set; }

        public ICollection<Encargo> Encargos { get; } = new List<Encargo>();
    }

}