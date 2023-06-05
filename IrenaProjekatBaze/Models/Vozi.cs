using System;
using System.Collections.Generic;

namespace IrenaProjekatBaze.Models;

public partial class Vozi
{
    public int VozacId { get; set; }

    public int VoziloId { get; set; }

    public virtual Vozac Vozac { get; set; } = null!;

    public virtual Vozilo Vozilo { get; set; } = null!;
}
