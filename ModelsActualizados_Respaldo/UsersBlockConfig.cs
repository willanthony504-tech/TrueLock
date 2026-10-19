using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class UsersBlockConfig
{
    public long UsbcId { get; set; }

    public long BlcoId { get; set; }

    public long AdministradorId { get; set; }

    public virtual User Administrador { get; set; } = null!;

    public virtual BlockConfig Blco { get; set; } = null!;
}
