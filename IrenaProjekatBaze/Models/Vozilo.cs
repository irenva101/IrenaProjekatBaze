using System;
using System.Collections.Generic;

namespace IrenaProjekatBaze.Models;

public partial class Vozilo
{
    public int VoziloId { get; set; }

    public string? Boja { get; set; }

    public int? God { get; set; }

    public virtual Autobu? Autobu { get; set; }

    public virtual Automobil? Automobil { get; set; }

    public virtual Kombi? Kombi { get; set; }

    public virtual ICollection<Putnik> Putniks { get; set; } = new List<Putnik>();

    public virtual ICollection<Rutum> Ruta { get; set; } = new List<Rutum>();
}
