using System;
using System.Collections.Generic;

namespace DOPRAVY_API.Models;

public partial class Encargo
{
    public decimal EncId { get; set; }

    public string EncTipoenc { get; set; } = null!;

    public string? EncDesc { get; set; }

    public string EncProvinciaid { get; set; } = null!;

    public string EncSector { get; set; } = null!;

    public string EncLugardescarga { get; set; } = null!;

    public string? EncConductorcedula { get; set; }

    public string? EncClicedula { get; set; }

    public string? EncUnidad { get; set; }

    public string? EncStatus { get; set; }

    public  Cliente? EncClicedulaNavigation { get; set; }

    public  Conductor? EncConductorcedulaNavigation { get; set; }

    public  Status? EncStatusNavigation { get; set; }

    public  Camion? EncUnidadNavigation { get; set; }
}
