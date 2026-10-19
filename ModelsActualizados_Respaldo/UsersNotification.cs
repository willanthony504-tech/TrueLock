using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class UsersNotification
{
    public long UsnoId { get; set; }

    public long UserId { get; set; }

    public long NotiId { get; set; }

    public virtual Notification Noti { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
