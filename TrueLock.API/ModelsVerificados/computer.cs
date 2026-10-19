using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsVerificados;

public partial class computer
{
    public long comp_id { get; set; }

    public string comp_name { get; set; } = null!;

    public string comp_status { get; set; } = null!;

    public DateTime comp_created_at { get; set; }

    public DateTime? comp_update_at { get; set; }

    public long? comp_update_by { get; set; }

    public long work_id { get; set; }

    public virtual ICollection<activity_log> activity_logs { get; set; } = new List<activity_log>();

    public virtual ICollection<unlock_requests_computer> unlock_requests_computers { get; set; } = new List<unlock_requests_computer>();

    public virtual ICollection<users_computer> users_computers { get; set; } = new List<users_computer>();

    public virtual workspace work { get; set; } = null!;
}
