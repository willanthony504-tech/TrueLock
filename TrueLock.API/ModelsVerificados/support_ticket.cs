using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsVerificados;

public partial class support_ticket
{
    public long suti_id { get; set; }

    public long noti_id { get; set; }

    public DateTime suti_created_at { get; set; }

    public long suti_created_by { get; set; }

    public string suti_priority { get; set; } = null!;

    public string suti_status { get; set; } = null!;

    public DateTime? suti_response_date { get; set; }

    public virtual notification noti { get; set; } = null!;
}
