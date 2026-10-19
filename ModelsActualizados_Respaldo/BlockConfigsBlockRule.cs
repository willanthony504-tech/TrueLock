using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class BlockConfigsBlockRule
{
    public long BlblId { get; set; }

    public long BlcoId { get; set; }

    public long BlruId { get; set; }

    public virtual BlockConfig Blco { get; set; } = null!;

    public virtual BlockRule Blru { get; set; } = null!;
}
