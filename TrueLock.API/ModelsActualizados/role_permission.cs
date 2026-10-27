using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class role_permission
{
    public long rope_id { get; set; }

    public long role_id { get; set; }

    public long perm_id { get; set; }

    public virtual permission perm { get; set; } = null!;

    public virtual role role { get; set; } = null!;
}
