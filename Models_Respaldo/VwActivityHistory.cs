using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrueLock.API.Models;

[Keyless]
public partial class VwActivityHistory
{
    [Column("aclo_id")]
    public long AcloId { get; set; }

    [Column("aclo_type", TypeName = "enum('SOFTWARE','WEB')")]
    public string AcloType { get; set; } = null!;

    [Column("aclo_resource", TypeName = "text")]
    public string AcloResource { get; set; } = null!;

    [Column("aclo_action", TypeName = "enum('BLOCKED','ALLOWED')")]
    public string AcloAction { get; set; } = null!;

    [Column("aclo_description", TypeName = "text")]
    public string AcloDescription { get; set; } = null!;

    [Column("aclo_created_at")]
    [MaxLength(6)]
    public DateTime AcloCreatedAt { get; set; }

    [Column("participante_id")]
    public long ParticipanteId { get; set; }

    [Column("user_names")]
    [StringLength(100)]
    public string UserNames { get; set; } = null!;

    [Column("user_last_names")]
    [StringLength(100)]
    public string UserLastNames { get; set; } = null!;

    [Column("comp_id")]
    public long CompId { get; set; }

    [Column("comp_name")]
    [StringLength(50)]
    public string CompName { get; set; } = null!;
}
