using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrueLock.API.Models;

[Table("permissions")]
[Index("PermCode", Name = "perm_code_UNIQUE", IsUnique = true)]
[Index("PermName", Name = "perm_name_UNIQUE", IsUnique = true)]
public partial class Permission
{
    [Key]
    [Column("perm_id")]
    public long PermId { get; set; }

    [Column("perm_name")]
    [StringLength(30)]
    public string PermName { get; set; } = null!;

    [Column("perm_description", TypeName = "text")]
    public string PermDescription { get; set; } = null!;

    [Column("perm_created_at")]
    [MaxLength(6)]
    public DateTime PermCreatedAt { get; set; }

    [Column("perm_created_by")]
    public long PermCreatedBy { get; set; }

    [Column("perm_update_at")]
    [MaxLength(6)]
    public DateTime? PermUpdateAt { get; set; }

    [Column("perm_update_by")]
    public long? PermUpdateBy { get; set; }

    [Column("perm_code")]
    [StringLength(30)]
    public string PermCode { get; set; } = null!;

    [InverseProperty("Perm")]
    public virtual ICollection<Access> Accesses { get; set; } = new List<Access>();

    [InverseProperty("Perm")]
    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
