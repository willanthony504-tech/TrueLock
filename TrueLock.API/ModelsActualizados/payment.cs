using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class payment
{
    public long paym_id { get; set; }

    public decimal paym_amount { get; set; }

    public string paym_currency { get; set; } = null!;

    public string paym_status { get; set; } = null!;

    public string? paym_reference { get; set; }

    public string paym_payment_method { get; set; } = null!;

    public DateTime paym_created_at { get; set; }

    public DateTime? paym_paid_at { get; set; }

    public string? paym_description { get; set; }

    public long subs_id { get; set; }

    public virtual subscription subs { get; set; } = null!;
}
