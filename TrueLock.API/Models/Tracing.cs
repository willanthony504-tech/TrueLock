using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrueLock.API.Models;

[Table("tracing")]
[Index("ParticipanteId", Name = "fk_tracing_participante_id_idx")]
public partial class Tracing
{
    [Key]
    [Column("trac_id")]
    public long TracId { get; set; }

    [Column("trac_name", TypeName = "enum('ACTIVITY_LOGS','SUPPORT','UNLOCK_REQUEST')")]
    public string TracName { get; set; } = null!;

    [Column("trac_created_at")]
    [MaxLength(6)]
    public DateTime TracCreatedAt { get; set; }

    [Column("trac_update_at")]
    [MaxLength(6)]
    public DateTime? TracUpdateAt { get; set; }

    [Column("trac_update_by")]
    public long? TracUpdateBy { get; set; }

    [Column("trac_created_by")]
    public long TracCreatedBy { get; set; }

    [Column("participante_id")]
    public long ParticipanteId { get; set; }

    [ForeignKey("ParticipanteId")]
    [InverseProperty("Tracings")]
    public virtual User Participante { get; set; } = null!;
}
