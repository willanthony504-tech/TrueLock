using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsVerificados;

public partial class notification
{
    public long noti_id { get; set; }

    public string noti_type { get; set; } = null!;

    public string noti_title { get; set; } = null!;

    public string noti_message { get; set; } = null!;

    public string noti_status { get; set; } = null!;

    public DateTime noti_created_at { get; set; }

    public long noti_created_by { get; set; }

    public virtual ICollection<support_ticket> support_tickets { get; set; } = new List<support_ticket>();

    public virtual ICollection<users_notification> users_notifications { get; set; } = new List<users_notification>();
}
