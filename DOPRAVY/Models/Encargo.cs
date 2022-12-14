using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOPRAVY.Models
{
    public partial class Encargo
    {
        public decimal EncId { get; set; }

        public int EncTipoencid { get; set; }

        public int EncProducid { get; set; }

        public string EncDesc { get; set; }

        public int EncProvinciaid { get; set; }

        public string EncSector { get; set; }

        public string EncLugardescarga { get; set; }

        public string EncConductorcedula { get; set; }

        public string EncClicedula { get; set; }

        public string EncUnidad { get; set; }

        public string EncStatus { get; set; }
    }

}