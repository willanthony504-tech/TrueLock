using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class BlockRule
{
    public long BlruId { get; set; }

    public string BlruType { get; set; } = null!;

    public string BlruName { get; set; } = null!;

    public string BlruPatron { get; set; } = null!;

    public string BlruDescription { get; set; } = null!;

    public DateTime BlruCreatedAt { get; set; }

    public long BlruCreatedBy { get; set; }

    public DateTime? BlruUpdateAt { get; set; }

    public long? BlruUpdateBy { get; set; }

    public virtual ICollection<BlockConfigsBlockRule> BlockConfigsBlockRules { get; set; } = new List<BlockConfigsBlockRule>();

    public virtual ICollection<BlockRulesUnlockRequest> BlockRulesUnlockRequests { get; set; } = new List<BlockRulesUnlockRequest>();

    public virtual ICollection<UsersBlockRule> UsersBlockRules { get; set; } = new List<UsersBlockRule>();
}
