using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrueLock.API.Models;

[Table("block_configs_block_rules")]
[Index("BlcoId", "BlruId", Name = "blco_blru_UNIQUE", IsUnique = true)]
[Index("BlcoId", Name = "fk_block_configs_block_rules_blco_id_idx")]
[Index("BlruId", Name = "fk_block_configs_block_rules_blru_id_id_idx")]
public partial class BlockConfigsBlockRule
{
    [Key]
    [Column("blbl_id")]
    public long BlblId { get; set; }

    [Column("blco_id")]
    public long BlcoId { get; set; }

    [Column("blru_id")]
    public long BlruId { get; set; }

    [ForeignKey("BlcoId")]
    [InverseProperty("BlockConfigsBlockRules")]
    public virtual BlockConfig Blco { get; set; } = null!;

    [ForeignKey("BlruId")]
    [InverseProperty("BlockConfigsBlockRules")]
    public virtual BlockRule Blru { get; set; } = null!;
}
