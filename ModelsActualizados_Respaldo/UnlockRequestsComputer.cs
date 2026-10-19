using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class UnlockRequestsComputer
{
    public long UncoId { get; set; }

    public long CompId { get; set; }

    public long UnreId { get; set; }

    public virtual Computer Comp { get; set; } = null!;

    public virtual UnlockRequest Unre { get; set; } = null!;
}
