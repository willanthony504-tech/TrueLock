using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class users_workspace
{
    public long uswo_id { get; set; }

    public long work_id { get; set; }

    public long administrador_id { get; set; }

    public long participante_id { get; set; }

    public virtual user administrador { get; set; } = null!;

    public virtual user participante { get; set; } = null!;

    public virtual workspace work { get; set; } = null!;
}
