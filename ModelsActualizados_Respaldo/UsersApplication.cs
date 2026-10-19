using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class UsersApplication
{
    public long UsapId { get; set; }

    public long AdministradorId { get; set; }

    public long ApplId { get; set; }

    public virtual User Administrador { get; set; } = null!;

    public virtual Application Appl { get; set; } = null!;
}
