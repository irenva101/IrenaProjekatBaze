using System;
using System.Collections.Generic;

namespace IrenaProjekatBaze.Models;

public partial class Korisnik
{
    public string Username { get; set; } = null!;

    public string? Password { get; set; }

    public string? Ime { get; set; }

    public string? Prezime { get; set; }

    public string? Jmbg { get; set; }
}
