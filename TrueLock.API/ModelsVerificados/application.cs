using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsVerificados;

public partial class application
{
    public long appl_id { get; set; }

    public string appl_name { get; set; } = null!;

    public string appl_executable_path { get; set; } = null!;

    public string? appl_image_path { get; set; }

    public string appl_status { get; set; } = null!;

    public DateTime appl_created_at { get; set; }

    public long appl_created_by { get; set; }

    public DateTime? appl_update_at { get; set; }

    public long? appl_update_by { get; set; }

    public virtual ICollection<users_application> users_applications { get; set; } = new List<users_application>();
}
