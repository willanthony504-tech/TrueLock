using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class BlockConfig
{
    public long BlcoId { get; set; }

    public string BlcoName { get; set; } = null!;

    public string BlcoDescription { get; set; } = null!;

    public DateTime BlcoCreatedAt { get; set; }

    public long BlcoCreatedBy { get; set; }

    public DateTime? BlcoUpdateAt { get; set; }

    public long? BlcoUpdateBy { get; set; }

    public virtual ICollection<BlockConfigsBlockRule> BlockConfigsBlockRules { get; set; } = new List<BlockConfigsBlockRule>();

    public virtual ICollection<UsersBlockConfig> UsersBlockConfigs { get; set; } = new List<UsersBlockConfig>();
}
