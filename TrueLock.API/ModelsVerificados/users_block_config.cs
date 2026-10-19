using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsVerificados;

public partial class users_block_config
{
    public long usbc_id { get; set; }

    public long blco_id { get; set; }

    public long administrador_id { get; set; }

    public virtual user administrador { get; set; } = null!;

    public virtual block_config blco { get; set; } = null!;
}
