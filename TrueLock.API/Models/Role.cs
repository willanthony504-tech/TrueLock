using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrueLock.API.Models;

[Table("roles")]
[Index("RoleCode", Name = "role_code_UNIQUE", IsUnique = true)]
[Index("RoleName", Name = "role_name_UNIQUE", IsUnique = true)]
public partial class Role
{
    [Key]
    [Column("role_id")]
    public long RoleId { get; set; }

    [Column("role_name", TypeName = "enum('DIRECTOR','ADMINISTRADOR','PARTICIPANTE')")]
    public string RoleName { get; set; } = null!;

    [Column("role_description", TypeName = "text")]
    public string RoleDescription { get; set; } = null!;

    [Column("role_created_at")]
    [MaxLength(6)]
    public DateTime RoleCreatedAt { get; set; }

    [Column("role_created_by")]
    public long RoleCreatedBy { get; set; }

    [Column("role_update_at")]
    [MaxLength(6)]
    public DateTime? RoleUpdateAt { get; set; }

    [Column("role_update_by")]
    public long? RoleUpdateBy { get; set; }

    [Column("role_code")]
    [StringLength(30)]
    public string RoleCode { get; set; } = null!;

    [InverseProperty("Role")]
    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    [InverseProperty("Role")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
