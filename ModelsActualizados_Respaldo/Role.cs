using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class Role
{
    public long RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public string RoleDescription { get; set; } = null!;

    public DateTime RoleCreatedAt { get; set; }

    public long RoleCreatedBy { get; set; }

    public DateTime? RoleUpdateAt { get; set; }

    public long? RoleUpdateBy { get; set; }

    public string RoleCode { get; set; } = null!;

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
