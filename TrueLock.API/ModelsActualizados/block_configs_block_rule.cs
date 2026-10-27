using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class block_configs_block_rule
{
    public long blbl_id { get; set; }

    public long blco_id { get; set; }

    public long blru_id { get; set; }

    public virtual block_config blco { get; set; } = null!;

    public virtual block_rule blru { get; set; } = null!;
}
