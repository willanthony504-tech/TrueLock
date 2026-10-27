using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class users_computer
{
    public long usco_id { get; set; }

    public long comp_id { get; set; }

    public long user_id { get; set; }

    public virtual computer comp { get; set; } = null!;

    public virtual user user { get; set; } = null!;
}
