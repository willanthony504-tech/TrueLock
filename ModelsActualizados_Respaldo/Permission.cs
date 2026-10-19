using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class Permission
{
    public long PermId { get; set; }

    public string PermName { get; set; } = null!;

    public string PermDescription { get; set; } = null!;

    public DateTime PermCreatedAt { get; set; }

    public long PermCreatedBy { get; set; }

    public DateTime? PermUpdateAt { get; set; }

    public long? PermUpdateBy { get; set; }

    public string PermCode { get; set; } = null!;

    public virtual ICollection<Access> Accesses { get; set; } = new List<Access>();

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
