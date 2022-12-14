using System;
using System.Collections.Generic;

namespace DOPRAVY_API.Models;

public partial class TipoSeguro
{
    public int TsId { get; set; }

    public string TsDesc { get; set; } = null!;

    public  ICollection<Camion> Camions { get; } = new List<Camion>();
}
