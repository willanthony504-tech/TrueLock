using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class ActivityLog
{
    public long AcloId { get; set; }

    public string AcloType { get; set; } = null!;

    public string AcloResource { get; set; } = null!;

    public string AcloAction { get; set; } = null!;

    public string AcloDescription { get; set; } = null!;

    public DateTime AcloCreatedAt { get; set; }

    public long AcloCreatedBy { get; set; }

    public long ParticipanteId { get; set; }

    public long CompId { get; set; }

    public virtual Computer Comp { get; set; } = null!;

    public virtual User Participante { get; set; } = null!;
}
