using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class role
{
    public long role_id { get; set; }

    public string role_name { get; set; } = null!;

    public string role_description { get; set; } = null!;

    public DateTime role_created_at { get; set; }

    public long role_created_by { get; set; }

    public DateTime? role_update_at { get; set; }

    public long? role_update_by { get; set; }

    public string role_code { get; set; } = null!;

    public virtual ICollection<role_permission> role_permissions { get; set; } = new List<role_permission>();

    public virtual ICollection<user> users { get; set; } = new List<user>();
}
