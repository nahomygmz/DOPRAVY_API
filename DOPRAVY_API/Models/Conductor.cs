using System;
using System.Collections.Generic;

namespace DOPRAVY_API.Models;

public partial class Conductor
{
    public string ConCedula { get; set; } = null!;

    public string ConNombre { get; set; } = null!;

    public string ConApellido { get; set; } = null!;

    public DateTime CliFechnac { get; set; }

    public string ConNacionalidad { get; set; } = null!;

    public string ConDireccion { get; set; } = null!;

    public string ConNiveledu { get; set; } = null!;

    public string ConSexo { get; set; } = null!;

    public string? ConStatus { get; set; }

    public  Sexo? ConSexoNavigation { get; set; } = null!;

    public  Status? ConStatusNavigation { get; set; }

    public  ICollection<Encargo> Encargos { get; } = new List<Encargo>();
}
