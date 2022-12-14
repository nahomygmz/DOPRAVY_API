using System;
using System.Collections.Generic;

namespace DOPRAVY_API.Models;

public partial class Usuario
{
    public string CliCedula { get; set; } = null!;

    public string CliPw { get; set; } = null!;

    public Cliente? CliCedulaNavigation { get; set; } = null!;
}
