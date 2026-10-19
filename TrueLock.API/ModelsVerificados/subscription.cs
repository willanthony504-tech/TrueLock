using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsVerificados;

public partial class subscription
{
    public long subs_id { get; set; }

    public DateTime subs_start_date { get; set; }

    public DateTime? subs_end_date { get; set; }

    public string subs_status { get; set; } = null!;

    public DateTime subs_created_at { get; set; }

    public long director_id { get; set; }

    public long plan_id { get; set; }

    public virtual user director { get; set; } = null!;

    public virtual ICollection<payment> payments { get; set; } = new List<payment>();

    public virtual plan plan { get; set; } = null!;
}
