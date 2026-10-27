using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class unlock_request
{
    public long unre_id { get; set; }

    public string unre_reason { get; set; } = null!;

    public string unre_status { get; set; } = null!;

    public DateTime unre_created_at { get; set; }

    public DateTime? unre_update_at { get; set; }

    public long? unre_update_by { get; set; }

    public long unre_created_by { get; set; }

    public DateTime? unre_response_date { get; set; }

    public long participante_id { get; set; }

    public long administrador_id { get; set; }

    public virtual user administrador { get; set; } = null!;

    public virtual ICollection<block_rules_unlock_request> block_rules_unlock_requests { get; set; } = new List<block_rules_unlock_request>();

    public virtual user participante { get; set; } = null!;

    public virtual ICollection<unlock_requests_computer> unlock_requests_computers { get; set; } = new List<unlock_requests_computer>();
}
