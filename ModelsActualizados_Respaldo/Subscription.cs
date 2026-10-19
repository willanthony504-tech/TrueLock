using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class Subscription
{
    public long SubsId { get; set; }

    public DateTime SubsStartDate { get; set; }

    public DateTime? SubsEndDate { get; set; }

    public string SubsStatus { get; set; } = null!;

    public DateTime SubsCreatedAt { get; set; }

    public long DirectorId { get; set; }

    public long PlanId { get; set; }

    public virtual User Director { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Plan Plan { get; set; } = null!;
}
