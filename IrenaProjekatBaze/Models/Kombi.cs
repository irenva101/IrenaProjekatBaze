using System;
using System.Collections.Generic;

namespace IrenaProjekatBaze.Models;

public partial class Kombi
{
    public int VoziloId { get; set; }

    public string? Nosivost { get; set; }

    public int? BrSedista { get; set; }

    public virtual Vozilo Vozilo { get; set; } = null!;
}
