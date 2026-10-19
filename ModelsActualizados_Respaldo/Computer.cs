using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class Computer
{
    public long CompId { get; set; }

    public string CompName { get; set; } = null!;

    public string CompStatus { get; set; } = null!;

    public DateTime CompCreatedAt { get; set; }

    public DateTime? CompUpdateAt { get; set; }

    public long? CompUpdateBy { get; set; }

    public long WorkId { get; set; }

    public virtual ICollection<ActivityLog> ActivityLogs { get; set; } = new List<ActivityLog>();

    public virtual ICollection<UnlockRequestsComputer> UnlockRequestsComputers { get; set; } = new List<UnlockRequestsComputer>();

    public virtual ICollection<UsersComputer> UsersComputers { get; set; } = new List<UsersComputer>();

    public virtual Workspace Work { get; set; } = null!;
}
