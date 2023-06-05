using System;
using System.Collections.Generic;

namespace IrenaProjekatBaze.Models;

public partial class Rezervacija
{
    public int RezId { get; set; }

    public int? BrSedista { get; set; }

    public int PutnikId { get; set; }

    public int TerminId { get; set; }

    public int UplataId { get; set; }

    public int RutaId { get; set; }

    public virtual Putnik Putnik { get; set; } = null!;

    public virtual Termin Termin { get; set; } = null!;

    public virtual Uplatum Uplatum { get; set; } = null!;
}
