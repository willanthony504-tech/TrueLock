using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class unlock_requests_computer
{
    public long unco_id { get; set; }

    public long comp_id { get; set; }

    public long unre_id { get; set; }

    public virtual computer comp { get; set; } = null!;

    public virtual unlock_request unre { get; set; } = null!;
}
