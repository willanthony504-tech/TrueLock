using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrueLock.API.Models;

[Table("unlock_requests")]
[Index("AdministradorId", Name = "fk_unlock_requests_administrador_id_idx")]
[Index("ParticipanteId", Name = "fk_unlock_requests_participante_id_idx")]
public partial class UnlockRequest
{
    [Key]
    [Column("unre_id")]
    public long UnreId { get; set; }

    [Column("unre_reason", TypeName = "text")]
    public string UnreReason { get; set; } = null!;

    [Column("unre_status", TypeName = "enum('PENDING','APPROVED','REJECTED')")]
    public string UnreStatus { get; set; } = null!;

    [Column("unre_created_at")]
    [MaxLength(6)]
    public DateTime UnreCreatedAt { get; set; }

    [Column("unre_update_at")]
    [MaxLength(6)]
    public DateTime? UnreUpdateAt { get; set; }

    [Column("unre_update_by")]
    public long? UnreUpdateBy { get; set; }

    [Column("unre_created_by")]
    public long UnreCreatedBy { get; set; }

    [Column("unre_response_date")]
    [MaxLength(6)]
    public DateTime? UnreResponseDate { get; set; }

    [Column("participante_id")]
    public long ParticipanteId { get; set; }

    [Column("administrador_id")]
    public long AdministradorId { get; set; }

    [ForeignKey("AdministradorId")]
    [InverseProperty("UnlockRequestAdministradors")]
    public virtual User Administrador { get; set; } = null!;

    [InverseProperty("Unre")]
    public virtual ICollection<BlockRulesUnlockRequest> BlockRulesUnlockRequests { get; set; } = new List<BlockRulesUnlockRequest>();

    [ForeignKey("ParticipanteId")]
    [InverseProperty("UnlockRequestParticipantes")]
    public virtual User Participante { get; set; } = null!;

    [InverseProperty("Unre")]
    public virtual ICollection<UnlockRequestsComputer> UnlockRequestsComputers { get; set; } = new List<UnlockRequestsComputer>();
}
