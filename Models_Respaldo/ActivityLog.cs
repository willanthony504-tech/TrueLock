using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrueLock.API.Models;

[Table("activity_logs")]
[Index("CompId", Name = "fk_activity_logs_comp_id_idx")]
[Index("ParticipanteId", Name = "fk_activity_logs_participante_id_idx")]
public partial class ActivityLog
{
    [Key]
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

    [Column("aclo_created_by")]
    public long AcloCreatedBy { get; set; }

    [Column("participante_id")]
    public long ParticipanteId { get; set; }

    [Column("comp_id")]
    public long CompId { get; set; }

    [ForeignKey("CompId")]
    [InverseProperty("ActivityLogs")]
    public virtual Computer Comp { get; set; } = null!;

    [ForeignKey("ParticipanteId")]
    [InverseProperty("ActivityLogs")]
    public virtual User Participante { get; set; } = null!;
}
