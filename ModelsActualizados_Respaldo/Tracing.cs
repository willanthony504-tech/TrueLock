using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class Tracing
{
    public long TracId { get; set; }

    public string TracName { get; set; } = null!;

    public DateTime TracCreatedAt { get; set; }

    public DateTime? TracUpdateAt { get; set; }

    public long? TracUpdateBy { get; set; }

    public long TracCreatedBy { get; set; }

    public long ParticipanteId { get; set; }

    public virtual User Participante { get; set; } = null!;
}
