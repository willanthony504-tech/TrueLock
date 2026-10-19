using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsVerificados;

public partial class block_rules_unlock_request
{
    public long blun_id { get; set; }

    public long blru_id { get; set; }

    public long unre_id { get; set; }

    public virtual block_rule blru { get; set; } = null!;

    public virtual unlock_request unre { get; set; } = null!;
}
