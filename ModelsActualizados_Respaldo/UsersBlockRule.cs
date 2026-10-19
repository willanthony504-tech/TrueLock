using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class UsersBlockRule
{
    public long UsbrId { get; set; }

    public long BlruId { get; set; }

    public long AdministradorId { get; set; }

    public virtual User Administrador { get; set; } = null!;

    public virtual BlockRule Blru { get; set; } = null!;
}
