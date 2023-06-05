using System;
using System.Collections.Generic;

namespace IrenaProjekatBaze.Models;

public partial class Automobil
{
    public int VoziloId { get; set; }

    public string? Pogon { get; set; }

    public int? Snaga { get; set; }

    public virtual Vozilo Vozilo { get; set; } = null!;
}
