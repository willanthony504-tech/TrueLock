using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class Application
{
    public long ApplId { get; set; }

    public string ApplName { get; set; } = null!;

    public string ApplExecutablePath { get; set; } = null!;

    public string? ApplImagePath { get; set; }

    public string ApplStatus { get; set; } = null!;

    public DateTime ApplCreatedAt { get; set; }

    public long ApplCreatedBy { get; set; }

    public DateTime? ApplUpdateAt { get; set; }

    public long? ApplUpdateBy { get; set; }

    public virtual ICollection<UsersApplication> UsersApplications { get; set; } = new List<UsersApplication>();
}
