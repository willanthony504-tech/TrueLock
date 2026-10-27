using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class permission
{
    public long perm_id { get; set; }

    public string perm_name { get; set; } = null!;

    public string perm_description { get; set; } = null!;

    public DateTime perm_created_at { get; set; }

    public long perm_created_by { get; set; }

    public DateTime? perm_update_at { get; set; }

    public long? perm_update_by { get; set; }

    public string perm_code { get; set; } = null!;

    public virtual ICollection<access> accesses { get; set; } = new List<access>();

    public virtual ICollection<role_permission> role_permissions { get; set; } = new List<role_permission>();
}
