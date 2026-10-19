using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrueLock.API.Models;

[Table("block_configs")]
public partial class BlockConfig
{
    [Key]
    [Column("blco_id")]
    public long BlcoId { get; set; }

    [Column("blco_name")]
    [StringLength(35)]
    public string BlcoName { get; set; } = null!;

    [Column("blco_description", TypeName = "text")]
    public string BlcoDescription { get; set; } = null!;

    [Column("blco_created_at")]
    [MaxLength(6)]
    public DateTime BlcoCreatedAt { get; set; }

    [Column("blco_created_by")]
    public long BlcoCreatedBy { get; set; }

    [Column("blco_update_at")]
    [MaxLength(6)]
    public DateTime? BlcoUpdateAt { get; set; }

    [Column("blco_update_by")]
    public long? BlcoUpdateBy { get; set; }

    [InverseProperty("Blco")]
    public virtual ICollection<BlockConfigsBlockRule> BlockConfigsBlockRules { get; set; } = new List<BlockConfigsBlockRule>();

    [InverseProperty("Blco")]
    public virtual ICollection<UsersBlockConfig> UsersBlockConfigs { get; set; } = new List<UsersBlockConfig>();
}
