using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrueLock.API.Models;

[Table("role_permissions")]
[Index("PermId", Name = "fk_role_permissions_perm_id_idx")]
[Index("RoleId", Name = "fk_role_permissions_role_id_idx")]
[Index("RoleId", "PermId", Name = "role_perm_UNIQUE", IsUnique = true)]
public partial class RolePermission
{
    [Key]
    [Column("rope_id")]
    public long RopeId { get; set; }

    [Column("role_id")]
    public long RoleId { get; set; }

    [Column("perm_id")]
    public long PermId { get; set; }

    [ForeignKey("PermId")]
    [InverseProperty("RolePermissions")]
    public virtual Permission Perm { get; set; } = null!;

    [ForeignKey("RoleId")]
    [InverseProperty("RolePermissions")]
    public virtual Role Role { get; set; } = null!;
}
