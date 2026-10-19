using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class UsersWebsite
{
    public long UsweId { get; set; }

    public long AdministradorId { get; set; }

    public long WebsId { get; set; }

    public virtual User Administrador { get; set; } = null!;

    public virtual Website Webs { get; set; } = null!;
}
