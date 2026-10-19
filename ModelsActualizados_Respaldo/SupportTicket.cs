using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class SupportTicket
{
    public long SutiId { get; set; }

    public long NotiId { get; set; }

    public DateTime SutiCreatedAt { get; set; }

    public long SutiCreatedBy { get; set; }

    public string SutiPriority { get; set; } = null!;

    public string SutiStatus { get; set; } = null!;

    public DateTime? SutiResponseDate { get; set; }

    public virtual Notification Noti { get; set; } = null!;
}
