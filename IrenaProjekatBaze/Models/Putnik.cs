using System;
using System.Collections.Generic;

namespace IrenaProjekatBaze.Models;

public partial class Putnik
{
    public int PutnikId { get; set; }

    public int VoziloId { get; set; }

    public string? Ime { get; set; }

    public string? Prezime { get; set; }

    public int? BrTel { get; set; }

    public virtual ICollection<Rezervacija> Rezervacijas { get; set; } = new List<Rezervacija>();

    public virtual ICollection<Uplatum> Uplata { get; set; } = new List<Uplatum>();

    public virtual Vozilo Vozilo { get; set; } = null!;
}
