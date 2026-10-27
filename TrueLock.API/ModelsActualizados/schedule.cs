using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class schedule
{
    public long sche_id { get; set; }

    public TimeOnly sche_start_time { get; set; }

    public TimeOnly sche_end_time { get; set; }

    public string sche_days { get; set; } = null!;


    public string sche_status { get; set; } = null!;

    public virtual ICollection<block_config> block_configs { get; set; } = new List<block_config>();

    public virtual ICollection<block_rule> block_rules { get; set; } = new List<block_rule>();
}
