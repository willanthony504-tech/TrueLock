using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class Workspace
{
    public long WorkId { get; set; }

    public string WorkName { get; set; } = null!;

    public DateTime WorkCreatedAt { get; set; }

    public DateTime? WorkUpdateAt { get; set; }

    public long? WorkUpdateBy { get; set; }

    public long WorkCreatedBy { get; set; }

    public long HeadId { get; set; }

    public virtual ICollection<Computer> Computers { get; set; } = new List<Computer>();

    public virtual Headquarter Head { get; set; } = null!;

    public virtual ICollection<UsersWorkspace> UsersWorkspaces { get; set; } = new List<UsersWorkspace>();
}
