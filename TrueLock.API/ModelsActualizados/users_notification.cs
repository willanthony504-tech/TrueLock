using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class users_notification
{
    public long usno_id { get; set; }

    public long user_id { get; set; }

    public long noti_id { get; set; }

    public virtual notification noti { get; set; } = null!;

    public virtual user user { get; set; } = null!;
}
