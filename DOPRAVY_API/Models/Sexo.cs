using System;
using System.Collections.Generic;

namespace DOPRAVY_API.Models;

public partial class Sexo
{
    public string SexoDesc { get; set; } = null!;

    public  ICollection<Cliente> Clientes { get; } = new List<Cliente>();

    public  ICollection<Conductor> Conductors { get; } = new List<Conductor>();
}
