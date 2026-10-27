using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class headquarter
{
    public long head_id { get; set; }

    public string head_name { get; set; } = null!;

    public string head_address { get; set; } = null!;

    public string head_email { get; set; } = null!;

    public DateTime head_created_at { get; set; }

    public DateTime? head_update_at { get; set; }

    public long? head_update_by { get; set; }

    public long head_created_by { get; set; }

    public long director_id { get; set; }

    public long administrador_id { get; set; }

    public string head_institutions_belong { get; set; } = null!;

    public virtual user administrador { get; set; } = null!;

    public virtual user director { get; set; } = null!;

    public virtual ICollection<workspace> workspaces { get; set; } = new List<workspace>();
}
