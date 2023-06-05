using System;
using System.Collections.Generic;

namespace IrenaProjekatBaze.Models;

public partial class Rutum
{
    public int RutaId { get; set; }

    public string? Polaziste { get; set; }

    public string? Odrediste { get; set; }

    public string? Vreme { get; set; }

    public string? Distanca { get; set; }

    public virtual ICollection<Termin> Termins { get; set; } = new List<Termin>();

    public virtual ICollection<Vozilo> Vozilos { get; set; } = new List<Vozilo>();
}
