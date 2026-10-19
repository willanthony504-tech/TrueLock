using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrueLock.API.Models;

[Table("unlock_requests_computers")]
[Index("CompId", Name = "fk_unlock_requests_computers_comp_id_idx")]
[Index("UnreId", Name = "fk_unlock_requests_computers_unre_id_idx")]
[Index("CompId", "UnreId", Name = "unco_comp_unre_UNIQUE", IsUnique = true)]
public partial class UnlockRequestsComputer
{
    [Key]
    [Column("unco_id")]
    public long UncoId { get; set; }

    [Column("comp_id")]
    public long CompId { get; set; }

    [Column("unre_id")]
    public long UnreId { get; set; }

    [ForeignKey("CompId")]
    [InverseProperty("UnlockRequestsComputers")]
    public virtual Computer Comp { get; set; } = null!;

    [ForeignKey("UnreId")]
    [InverseProperty("UnlockRequestsComputers")]
    public virtual UnlockRequest Unre { get; set; } = null!;
}
