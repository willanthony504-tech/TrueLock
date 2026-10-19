using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class UnlockRequest
{
    public long UnreId { get; set; }

    public string UnreReason { get; set; } = null!;

    public string UnreStatus { get; set; } = null!;

    public DateTime UnreCreatedAt { get; set; }

    public DateTime? UnreUpdateAt { get; set; }

    public long? UnreUpdateBy { get; set; }

    public long UnreCreatedBy { get; set; }

    public DateTime? UnreResponseDate { get; set; }

    public long ParticipanteId { get; set; }

    public long AdministradorId { get; set; }

    public virtual User Administrador { get; set; } = null!;

    public virtual ICollection<BlockRulesUnlockRequest> BlockRulesUnlockRequests { get; set; } = new List<BlockRulesUnlockRequest>();

    public virtual User Participante { get; set; } = null!;

    public virtual ICollection<UnlockRequestsComputer> UnlockRequestsComputers { get; set; } = new List<UnlockRequestsComputer>();
}
