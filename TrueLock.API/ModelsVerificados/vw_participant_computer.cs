using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsVerificados;

public partial class vw_participant_computer
{
    public long user_id { get; set; }

    public string user_names { get; set; } = null!;

    public string user_last_names { get; set; } = null!;

    public long comp_id { get; set; }

    public string comp_name { get; set; } = null!;

    public string comp_status { get; set; } = null!;

    public long work_id { get; set; }

    public string work_name { get; set; } = null!;
}
