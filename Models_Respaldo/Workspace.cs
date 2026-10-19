using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrueLock.API.Models;

[Table("workspaces")]
[Index("HeadId", Name = "fk_workspaces_head_id_idx")]
public partial class Workspace
{
    [Key]
    [Column("work_id")]
    public long WorkId { get; set; }

    [Column("work_name")]
    [StringLength(35)]
    public string WorkName { get; set; } = null!;

    [Column("work_created_at")]
    [MaxLength(6)]
    public DateTime WorkCreatedAt { get; set; }

    [Column("work_update_at")]
    [MaxLength(6)]
    public DateTime? WorkUpdateAt { get; set; }

    [Column("work_update_by")]
    public long? WorkUpdateBy { get; set; }

    [Column("work_created_by")]
    public long WorkCreatedBy { get; set; }

    [Column("head_id")]
    public long HeadId { get; set; }

    [InverseProperty("Work")]
    public virtual ICollection<Computer> Computers { get; set; } = new List<Computer>();

    [ForeignKey("HeadId")]
    [InverseProperty("Workspaces")]
    public virtual Headquarter Head { get; set; } = null!;

    [InverseProperty("Work")]
    public virtual ICollection<UsersWorkspace> UsersWorkspaces { get; set; } = new List<UsersWorkspace>();
}
