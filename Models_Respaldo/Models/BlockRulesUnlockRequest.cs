using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrueLock.API.Models;

[Table("block_rules_unlock_requests")]
[Index("BlruId", Name = "fk_block_rules_unlock_requests_blru_id_idx")]
[Index("UnreId", Name = "fk_block_rules_unlock_requests_unre_id_id_idx")]
public partial class BlockRulesUnlockRequest
{
    [Key]
    [Column("blun_id")]
    public long BlunId { get; set; }

    [Column("blru_id")]
    public long BlruId { get; set; }

    [Column("unre_id")]
    public long UnreId { get; set; }

    [ForeignKey("BlruId")]
    [InverseProperty("BlockRulesUnlockRequests")]
    public virtual BlockRule Blru { get; set; } = null!;

    [ForeignKey("UnreId")]
    [InverseProperty("BlockRulesUnlockRequests")]
    public virtual UnlockRequest Unre { get; set; } = null!;
}
