using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrueLock.API.Models;

[Table("accesses")]
[Index("AcceUsername", Name = "acce_username_UNIQUE", IsUnique = true)]
[Index("PermId", Name = "fk_access_perm_id_idx")]
[Index("UserId", Name = "fk_accesses_user_id_idx")]
public partial class Access
{
    [Key]
    [Column("acce_id")]
    public long AcceId { get; set; }

    [Column("perm_id")]
    public long PermId { get; set; }

    [Column("acce_username")]
    [StringLength(40)]
    public string AcceUsername { get; set; } = null!;

    [Column("acce_description", TypeName = "text")]
    public string AcceDescription { get; set; } = null!;

    [Column("acce_created_at")]
    [MaxLength(6)]
    public DateTime AcceCreatedAt { get; set; }

    [Column("acce_created_by")]
    public long AcceCreatedBy { get; set; }

    [Column("acce_update_by")]
    public long? AcceUpdateBy { get; set; }

    [Column("acce_update_at")]
    [MaxLength(6)]
    public DateTime? AcceUpdateAt { get; set; }

    [Column("acce_password_hash")]
    [StringLength(255)]
    public string AccePasswordHash { get; set; } = null!;

    [Column("acce_status", TypeName = "enum('ACTIVE','INACTIVE','LOCKED')")]
    public string AcceStatus { get; set; } = null!;

    [Column("acce_failed_attempts")]
    public int AcceFailedAttempts { get; set; }

    [Column("acce_locked_until")]
    [MaxLength(6)]
    public DateTime? AcceLockedUntil { get; set; }

    [Column("acce_last_login_at")]
    [MaxLength(6)]
    public DateTime? AcceLastLoginAt { get; set; }

    [Column("acce_password_changed_at")]
    [MaxLength(6)]
    public DateTime AccePasswordChangedAt { get; set; }

    [Column("user_id")]
    public long UserId { get; set; }

    [ForeignKey("PermId")]
    [InverseProperty("Accesses")]
    public virtual Permission Perm { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Accesses")]
    public virtual User User { get; set; } = null!;
}
