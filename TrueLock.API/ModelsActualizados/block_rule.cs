using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class block_rule
{
    public long blru_id { get; set; }

    public string blru_type { get; set; } = null!;

    public string blru_name { get; set; } = null!;

    public string blru_patron { get; set; } = null!;

    public string blru_description { get; set; } = null!;

    public DateTime blru_created_at { get; set; }

    public long blru_created_by { get; set; }

    public DateTime? blru_update_at { get; set; }

    public long? blru_update_by { get; set; }

    public long sche_id { get; set; }

    public virtual ICollection<block_configs_block_rule> block_configs_block_rules { get; set; } = new List<block_configs_block_rule>();

    public virtual ICollection<block_rules_unlock_request> block_rules_unlock_requests { get; set; } = new List<block_rules_unlock_request>();

    public virtual schedule sche { get; set; } = null!;

    public virtual ICollection<users_block_rule> users_block_rules { get; set; } = new List<users_block_rule>();
}
