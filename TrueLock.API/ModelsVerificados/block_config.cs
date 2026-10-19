using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsVerificados;

public partial class block_config
{
    public long blco_id { get; set; }

    public string blco_name { get; set; } = null!;

    public string blco_description { get; set; } = null!;

    public DateTime blco_created_at { get; set; }

    public long blco_created_by { get; set; }

    public DateTime? blco_update_at { get; set; }

    public long? blco_update_by { get; set; }

    public virtual ICollection<block_configs_block_rule> block_configs_block_rules { get; set; } = new List<block_configs_block_rule>();

    public virtual ICollection<users_block_config> users_block_configs { get; set; } = new List<users_block_config>();
}
