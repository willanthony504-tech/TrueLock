using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class Notification
{
    public long NotiId { get; set; }

    public string NotiType { get; set; } = null!;

    public string NotiTitle { get; set; } = null!;

    public string NotiMessage { get; set; } = null!;

    public string NotiStatus { get; set; } = null!;

    public DateTime NotiCreatedAt { get; set; }

    public long NotiCreatedBy { get; set; }

    public virtual ICollection<SupportTicket> SupportTickets { get; set; } = new List<SupportTicket>();

    public virtual ICollection<UsersNotification> UsersNotifications { get; set; } = new List<UsersNotification>();
}
