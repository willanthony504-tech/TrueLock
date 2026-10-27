using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class workspace
{
    public long work_id { get; set; }

    public string work_name { get; set; } = null!;

    public DateTime work_created_at { get; set; }

    public DateTime? work_update_at { get; set; }

    public long? work_update_by { get; set; }

    public long work_created_by { get; set; }

    public long head_id { get; set; }

    public long? work_owner_admin_id { get; set; }

    public virtual ICollection<computer> computers { get; set; } = new List<computer>();

    public virtual headquarter head { get; set; } = null!;

    public virtual ICollection<users_workspace> users_workspaces { get; set; } = new List<users_workspace>();

    public virtual user? work_owner_admin { get; set; }
}
