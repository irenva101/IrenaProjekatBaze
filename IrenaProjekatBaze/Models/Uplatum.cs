using System;
using System.Collections.Generic;

namespace IrenaProjekatBaze.Models;

public partial class Uplatum
{
    public int UplataId { get; set; }

    public int PutnikId { get; set; }

    public int? Iznos { get; set; }

    public string? Datum { get; set; }

    public string? NacinPl { get; set; }

    public virtual Putnik Putnik { get; set; } = null!;

    public virtual ICollection<Rezervacija> Rezervacijas { get; set; } = new List<Rezervacija>();
}
