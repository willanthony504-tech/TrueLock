using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class Schedule
{
    public long ScheId { get; set; }

    public TimeOnly ScheStartTime { get; set; }

    public TimeOnly ScheEndTime { get; set; }
    public string ScheDays { get; set; } = null!;

    public string ScheStatus { get; set; } = null!;
}
