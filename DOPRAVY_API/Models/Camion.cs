using System;
using System.Collections.Generic;

namespace DOPRAVY_API.Models;

public partial class Camion
{
    public string CamUnidad { get; set; } = null!;

    public string CamMarca { get; set; } = null!;

    public string CamModelo { get; set; } = null!;

    public string CamColor { get; set; } = null!;

    public string CamPlaca { get; set; } = null!;

    public string CamChasis { get; set; } = null!;

    public string CamTipovehiculo { get; set; } = null!;

    public string CamTiposeguroid { get; set; } = null!;

    public string CamStatus { get; set; } = null!;

    public  Status? CamStatusNavigation { get; set; } = null!;

    public  TipoSeguro? CamTiposeguro { get; set; } = null!;

    public  ICollection<Encargo> Encargos { get; } = new List<Encargo>();
}
