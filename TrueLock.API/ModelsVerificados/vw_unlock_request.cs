using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsVerificados;

public partial class vw_unlock_request
{
    public long unre_id { get; set; }

    public string unre_reason { get; set; } = null!;

    public string unre_status { get; set; } = null!;

    public DateTime unre_created_at { get; set; }

    public DateTime? unre_response_date { get; set; }

    public long participante_id { get; set; }

    public string user_names { get; set; } = null!;

    public string user_last_names { get; set; } = null!;

    public long administrador_id { get; set; }

    public string administrador_names { get; set; } = null!;

    public string administrador_last_names { get; set; } = null!;
}
