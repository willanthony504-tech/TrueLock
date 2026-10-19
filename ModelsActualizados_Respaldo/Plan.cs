using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class Plan
{
    public long PlanId { get; set; }

    public string PlanName { get; set; } = null!;

    public string PlanDescription { get; set; } = null!;

    public decimal PlanPrice { get; set; }

    public int PlanMaxComputers { get; set; }

    public int? PlanDurationsDays { get; set; }

    public string PlanStatus { get; set; } = null!;

    public DateTime PlanCreatedAt { get; set; }

    public DateTime? PlanUpdateAt { get; set; }

    public long PlanCreatedBy { get; set; }

    public long? PlanUpdateBy { get; set; }

    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
}
