using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrueLock.API.Models;

[Keyless]
public partial class VwUnlockRequest
{
    [Column("unre_id")]
    public long UnreId { get; set; }

    [Column("unre_reason", TypeName = "text")]
    public string UnreReason { get; set; } = null!;

    [Column("unre_status", TypeName = "enum('PENDING','APPROVED','REJECTED')")]
    public string UnreStatus { get; set; } = null!;

    [Column("unre_created_at")]
    [MaxLength(6)]
    public DateTime UnreCreatedAt { get; set; }

    [Column("unre_response_date")]
    [MaxLength(6)]
    public DateTime? UnreResponseDate { get; set; }

    [Column("participante_id")]
    public long ParticipanteId { get; set; }

    [Column("user_names")]
    [StringLength(100)]
    public string UserNames { get; set; } = null!;

    [Column("user_last_names")]
    [StringLength(100)]
    public string UserLastNames { get; set; } = null!;

    [Column("administrador_id")]
    public long AdministradorId { get; set; }

    [Column("administrador_names")]
    [StringLength(100)]
    public string AdministradorNames { get; set; } = null!;

    [Column("administrador_last_names")]
    [StringLength(100)]
    public string AdministradorLastNames { get; set; } = null!;
}
