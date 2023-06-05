using System;
using System.Collections.Generic;

namespace IrenaProjekatBaze.Models;

public partial class Termin
{
    public int TerminId { get; set; }

    public int RutaId { get; set; }

    public int VozacId { get; set; }

    public string? Datum { get; set; }

    public string? Vreme { get; set; }

    public virtual ICollection<Rezervacija> Rezervacijas { get; set; } = new List<Rezervacija>();

    public virtual Rutum Ruta { get; set; } = null!;

    public virtual Vozac Vozac { get; set; } = null!;
}
