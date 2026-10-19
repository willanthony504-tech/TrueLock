using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsVerificados;

public partial class users_application
{
    public long usap_id { get; set; }

    public long administrador_id { get; set; }

    public long appl_id { get; set; }

    public virtual user administrador { get; set; } = null!;

    public virtual application appl { get; set; } = null!;
}
