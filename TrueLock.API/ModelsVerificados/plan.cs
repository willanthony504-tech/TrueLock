using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsVerificados;

public partial class plan
{
    public long plan_id { get; set; }

    public string plan_name { get; set; } = null!;

    public string plan_description { get; set; } = null!;

    public decimal plan_price { get; set; }

    public int plan_max_computers { get; set; }

    public int? plan_durations_days { get; set; }

    public string plan_status { get; set; } = null!;

    public DateTime plan_created_at { get; set; }

    public DateTime? plan_update_at { get; set; }

    public long plan_created_by { get; set; }

    public long? plan_update_by { get; set; }

    public virtual ICollection<subscription> subscriptions { get; set; } = new List<subscription>();
}
