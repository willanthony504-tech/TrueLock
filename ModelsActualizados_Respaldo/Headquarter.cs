using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class Headquarter
{
    public long HeadId { get; set; }

    public string HeadName { get; set; } = null!;

    public string HeadAddress { get; set; } = null!;

    public string HeadEmail { get; set; } = null!;

    public DateTime HeadCreatedAt { get; set; }

    public DateTime? HeadUpdateAt { get; set; }

    public long? HeadUpdateBy { get; set; }

    public long HeadCreatedBy { get; set; }

    public long DirectorId { get; set; }

    public long AdministradorId { get; set; }

    public string HeadInstitutionsBelong { get; set; } = null!;

    public virtual User Administrador { get; set; } = null!;

    public virtual User Director { get; set; } = null!;

    public virtual ICollection<Workspace> Workspaces { get; set; } = new List<Workspace>();
}
