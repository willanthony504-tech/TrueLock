using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class Access
{
    public long AcceId { get; set; }

    public long PermId { get; set; }

    public string AcceDescription { get; set; } = null!;

    public DateTime AcceCreatedAt { get; set; }

    public long AcceCreatedBy { get; set; }

    public long? AcceUpdateBy { get; set; }

    public DateTime? AcceUpdateAt { get; set; }

    public int AcceFailedAttempts { get; set; }

    public DateTime? AcceLockedUntil { get; set; }

    public DateTime? AcceLastLoginAt { get; set; }

    public long UserId { get; set; }

    public virtual Permission Perm { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
