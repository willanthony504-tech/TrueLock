using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class users_website
{
    public long uswe_id { get; set; }

    public long administrador_id { get; set; }

    public long webs_id { get; set; }

    public virtual user administrador { get; set; } = null!;

    public virtual website webs { get; set; } = null!;
}
