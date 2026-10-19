using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsVerificados;

public partial class vw_activity_history
{
    public long aclo_id { get; set; }

    public string aclo_type { get; set; } = null!;

    public string aclo_resource { get; set; } = null!;

    public string aclo_action { get; set; } = null!;

    public string aclo_description { get; set; } = null!;

    public DateTime aclo_created_at { get; set; }

    public long participante_id { get; set; }

    public string user_names { get; set; } = null!;

    public string user_last_names { get; set; } = null!;

    public long comp_id { get; set; }

    public string comp_name { get; set; } = null!;
}
