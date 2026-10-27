using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class tracing
{
    public long trac_id { get; set; }

    public string trac_name { get; set; } = null!;

    public DateTime trac_created_at { get; set; }

    public DateTime? trac_update_at { get; set; }

    public long? trac_update_by { get; set; }

    public long trac_created_by { get; set; }

    public long participante_id { get; set; }

    public virtual user participante { get; set; } = null!;
}
