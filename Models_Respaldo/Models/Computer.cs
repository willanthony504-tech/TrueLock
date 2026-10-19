using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrueLock.API.Models;

[Table("computers")]
[Index("WorkId", Name = "fk_computers_work_id_idx")]
public partial class Computer
{
    [Key]
    [Column("comp_id")]
    public long CompId { get; set; }

    [Column("comp_name")]
    [StringLength(50)]
    public string CompName { get; set; } = null!;

    [Column("comp_status", TypeName = "enum('ACTIVE','INACTIVE')")]
    public string CompStatus { get; set; } = null!;

    [Column("comp_created_at")]
    [MaxLength(6)]
    public DateTime CompCreatedAt { get; set; }

    [Column("comp_update_at")]
    [MaxLength(6)]
    public DateTime? CompUpdateAt { get; set; }

    [Column("comp_update_by")]
    public long? CompUpdateBy { get; set; }

    [Column("work_id")]
    public long WorkId { get; set; }

    [InverseProperty("Comp")]
    public virtual ICollection<ActivityLog> ActivityLogs { get; set; } = new List<ActivityLog>();

    [InverseProperty("Comp")]
    public virtual ICollection<UnlockRequestsComputer> UnlockRequestsComputers { get; set; } = new List<UnlockRequestsComputer>();

    [InverseProperty("Comp")]
    public virtual ICollection<UsersComputer> UsersComputers { get; set; } = new List<UsersComputer>();

    [ForeignKey("WorkId")]
    [InverseProperty("Computers")]
    public virtual Workspace Work { get; set; } = null!;
}
