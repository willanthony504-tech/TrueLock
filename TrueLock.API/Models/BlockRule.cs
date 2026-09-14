using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrueLock.API.Models;

[Table("block_rules")]
[Index("BlruName", Name = "blru_name_UNIQUE", IsUnique = true)]
public partial class BlockRule
{
    [Key]
    [Column("blru_id")]
    public long BlruId { get; set; }

    [Column("blru_type", TypeName = "enum('SOFTWARE','WEB')")]
    public string BlruType { get; set; } = null!;

    [Column("blru_name")]
    [StringLength(40)]
    public string BlruName { get; set; } = null!;

    [Column("blru_patron", TypeName = "enum('BLOCKED','ALLOWED')")]
    public string BlruPatron { get; set; } = null!;

    [Column("blru_description", TypeName = "text")]
    public string BlruDescription { get; set; } = null!;

    [Column("blru_created_at")]
    [MaxLength(6)]
    public DateTime BlruCreatedAt { get; set; }

    [Column("blru_created_by")]
    public long BlruCreatedBy { get; set; }

    [Column("blru_update_at")]
    [MaxLength(6)]
    public DateTime? BlruUpdateAt { get; set; }

    [Column("blru_update_by")]
    public long? BlruUpdateBy { get; set; }

    [InverseProperty("Blru")]
    public virtual ICollection<BlockConfigsBlockRule> BlockConfigsBlockRules { get; set; } = new List<BlockConfigsBlockRule>();

    [InverseProperty("Blru")]
    public virtual ICollection<BlockRulesUnlockRequest> BlockRulesUnlockRequests { get; set; } = new List<BlockRulesUnlockRequest>();

    [InverseProperty("Blru")]
    public virtual ICollection<UsersBlockRule> UsersBlockRules { get; set; } = new List<UsersBlockRule>();
}
