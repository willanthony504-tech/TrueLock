using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class UsersWorkspace
{
    public long UswoId { get; set; }

    public long WorkId { get; set; }

    public long AdministradorId { get; set; }

    public long ParticipanteId { get; set; }

    public virtual User Administrador { get; set; } = null!;

    public virtual User Participante { get; set; } = null!;

    public virtual Workspace Work { get; set; } = null!;
}
