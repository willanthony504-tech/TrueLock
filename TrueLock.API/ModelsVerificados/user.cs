using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsVerificados;

public partial class user
{
    public long user_id { get; set; }

    public long role_id { get; set; }

    public string user_email { get; set; } = null!;

    public DateTime user_created_at { get; set; }

    public long user_created_by { get; set; }

    public DateTime? user_update_at { get; set; }

    public long? user_update_by { get; set; }

    public string user_status { get; set; } = null!;

    public string user_names { get; set; } = null!;

    public string user_last_names { get; set; } = null!;

    public DateOnly user_birth_date { get; set; }

    public string user_sex { get; set; } = null!;

    public string user_gender { get; set; } = null!;

    public string user_document_type { get; set; } = null!;

    public string user_document_number { get; set; } = null!;

    public string user_phone_number { get; set; } = null!;

    public string user_country_code { get; set; } = null!;

    public string? user_profile_photo { get; set; }

    public string user_username { get; set; } = null!;

    public DateTime? user_password_changed_at { get; set; }

    public string user_password_hash { get; set; } = null!;

    public virtual ICollection<access> accesses { get; set; } = new List<access>();

    public virtual ICollection<activity_log> activity_logs { get; set; } = new List<activity_log>();

    public virtual ICollection<headquarter> headquarteradministradors { get; set; } = new List<headquarter>();

    public virtual ICollection<headquarter> headquarterdirectors { get; set; } = new List<headquarter>();

    public virtual role role { get; set; } = null!;

    public virtual ICollection<subscription> subscriptions { get; set; } = new List<subscription>();

    public virtual ICollection<tracing> tracings { get; set; } = new List<tracing>();

    public virtual ICollection<unlock_request> unlock_requestadministradors { get; set; } = new List<unlock_request>();

    public virtual ICollection<unlock_request> unlock_requestparticipantes { get; set; } = new List<unlock_request>();

    public virtual ICollection<users_application> users_applications { get; set; } = new List<users_application>();

    public virtual ICollection<users_block_config> users_block_configs { get; set; } = new List<users_block_config>();

    public virtual ICollection<users_block_rule> users_block_rules { get; set; } = new List<users_block_rule>();

    public virtual ICollection<users_computer> users_computers { get; set; } = new List<users_computer>();

    public virtual ICollection<users_notification> users_notifications { get; set; } = new List<users_notification>();

    public virtual ICollection<users_website> users_websites { get; set; } = new List<users_website>();

    public virtual ICollection<users_workspace> users_workspaceadministradors { get; set; } = new List<users_workspace>();

    public virtual users_workspace? users_workspaceparticipante { get; set; }
}
