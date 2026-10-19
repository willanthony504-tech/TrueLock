using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsVerificados;

public partial class users_block_rule
{
    public long usbr_id { get; set; }

    public long blru_id { get; set; }

    public long administrador_id { get; set; }

    public virtual user administrador { get; set; } = null!;

    public virtual block_rule blru { get; set; } = null!;
}
