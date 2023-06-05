using System;
using System.Collections.Generic;

namespace IrenaProjekatBaze.Models;

public partial class Autobu
{
    public int VoziloId { get; set; }

    public int? BrSedista { get; set; }

    public string? Marka { get; set; }

    public virtual Vozilo Vozilo { get; set; } = null!;
}
