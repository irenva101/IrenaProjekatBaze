using System;
using System.Collections.Generic;

namespace IrenaProjekatBaze.Models;

public partial class Vozac
{
    public int VozacId { get; set; }

    public int? BrTel { get; set; }

    public string? Prezime { get; set; }

    public string? Ime { get; set; }

    public int? BrVozacke { get; set; }

    public virtual ICollection<Termin> Termins { get; set; } = new List<Termin>();
}
