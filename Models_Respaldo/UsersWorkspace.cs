using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrueLock.API.Models;

[Table("users_workspaces")]
[Index("AdministradorId", Name = "fk_users_workspaces_administrador_id_idx")]
[Index("ParticipanteId", Name = "fk_users_workspaces_participante_id_idx", IsUnique = true)]
[Index("WorkId", Name = "fk_users_workspaces_work_id_idx")]
public partial class UsersWorkspace
{
    [Key]
    [Column("uswo_id")]
    public long UswoId { get; set; }

    [Column("work_id")]
    public long WorkId { get; set; }

    [Column("administrador_id")]
    public long AdministradorId { get; set; }

    [Column("participante_id")]
    public long ParticipanteId { get; set; }

    [ForeignKey("AdministradorId")]
    [InverseProperty("UsersWorkspaceAdministradors")]
    public virtual User Administrador { get; set; } = null!;

    [ForeignKey("ParticipanteId")]
    [InverseProperty("UsersWorkspaceParticipante")]
    public virtual User Participante { get; set; } = null!;

    [ForeignKey("WorkId")]
    [InverseProperty("UsersWorkspaces")]
    public virtual Workspace Work { get; set; } = null!;
}
