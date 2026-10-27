using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class website
{
    public long webs_id { get; set; }

    public string webs_url { get; set; } = null!;

    public string? webs_image_path { get; set; }

    public string webs_status { get; set; } = null!;

    public DateTime webs_created_at { get; set; }

    public long webs_created_by { get; set; }

    public byte[] webs_url_hash { get; set; } = null!;

    public virtual ICollection<users_website> users_websites { get; set; } = new List<users_website>();
}
