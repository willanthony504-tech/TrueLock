using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class BlockRulesUnlockRequest
{
    public long BlunId { get; set; }

    public long BlruId { get; set; }

    public long UnreId { get; set; }

    public virtual BlockRule Blru { get; set; } = null!;

    public virtual UnlockRequest Unre { get; set; } = null!;
}
