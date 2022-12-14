using System;
using System.Collections.Generic;

namespace DOPRAVY_API.Models;

public partial class Status
{
    public string StaDesc { get; set; } = null!;

    public  ICollection<Camion> Camions { get; } = new List<Camion>();

    public  ICollection<Cliente> Clientes { get; } = new List<Cliente>();

    public  ICollection<Conductor> Conductors { get; } = new List<Conductor>();

    public  ICollection<Encargo> Encargos { get; } = new List<Encargo>();
}
