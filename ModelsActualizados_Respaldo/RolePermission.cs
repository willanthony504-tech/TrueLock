using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class RolePermission
{
    public long RopeId { get; set; }

    public long RoleId { get; set; }

    public long PermId { get; set; }

    public virtual Permission Perm { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
