using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsVerificados;

public partial class schedule
{
    public long sche_id { get; set; }

    public TimeOnly sche_start_time { get; set; }

    public TimeOnly sche_end_time { get; set; }
    public string sche_days { get; set; } = null!;

    public string sche_status { get; set; } = null!;
}
