using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsVerificados;

public partial class activity_log
{
    public long aclo_id { get; set; }

    public string aclo_type { get; set; } = null!;

    public string aclo_resource { get; set; } = null!;

    public string aclo_action { get; set; } = null!;

    public string aclo_description { get; set; } = null!;

    public DateTime aclo_created_at { get; set; }

    public long aclo_created_by { get; set; }

    public long participante_id { get; set; }

    public long comp_id { get; set; }

    public virtual computer comp { get; set; } = null!;

    public virtual user participante { get; set; } = null!;
}
