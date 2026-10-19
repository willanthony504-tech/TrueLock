using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class Website
{
    public long WebsId { get; set; }

    public string WebsUrl { get; set; } = null!;

    public string? WebsImagePath { get; set; }

    public string WebsStatus { get; set; } = null!;

    public DateTime WebsCreatedAt { get; set; }

    public long WebsCreatedBy { get; set; }

    public byte[] WebsUrlHash { get; set; } = null!;

    public virtual ICollection<UsersWebsite> UsersWebsites { get; set; } = new List<UsersWebsite>();
}
