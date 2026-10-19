using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class Payment
{
    public long PaymId { get; set; }

    public decimal PaymAmount { get; set; }

    public string PaymCurrency { get; set; } = null!;

    public string PaymStatus { get; set; } = null!;

    public string? PaymReference { get; set; }

    public string PaymPaymentMethod { get; set; } = null!;

    public DateTime PaymCreatedAt { get; set; }

    public DateTime? PaymPaidAt { get; set; }

    public string? PaymDescription { get; set; }

    public long SubsId { get; set; }

    public virtual Subscription Subs { get; set; } = null!;
}
