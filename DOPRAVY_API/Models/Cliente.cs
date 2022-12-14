using System;
using System.Collections.Generic;

namespace DOPRAVY_API.Models;

public partial class Cliente
{
    public string CliCedula { get; set; } = null!;

    public string CliNombre { get; set; } = null!;

    public string CliApellido { get; set; } = null!;

    public DateTime CliFechnac { get; set; }

    public string CliSexo { get; set; } = null!;

    public string? CliStatus { get; set; }

    public string CliPw { get; set; } = null!;

    public  Sexo? CliSexoNavigation { get; set; } = null!;

    public  Status? CliStatusNavigation { get; set; }

    public  ICollection<Encargo> Encargos { get; } = new List<Encargo>();

    public  Usuario? Usuario { get; set; }
}
