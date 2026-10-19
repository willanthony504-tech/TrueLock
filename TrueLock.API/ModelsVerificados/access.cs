using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsVerificados;

public partial class access
{
    public long acce_id { get; set; }

    public long perm_id { get; set; }

    public string acce_description { get; set; } = null!;

    public DateTime acce_created_at { get; set; }

    public long acce_created_by { get; set; }

    public long? acce_update_by { get; set; }

    public DateTime? acce_update_at { get; set; }

    public int acce_failed_attempts { get; set; }

    public DateTime? acce_locked_until { get; set; }

    public DateTime? acce_last_login_at { get; set; }

    public long user_id { get; set; }

    public virtual permission perm { get; set; } = null!;

    public virtual user user { get; set; } = null!;
}
