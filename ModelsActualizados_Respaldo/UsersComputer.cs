using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class UsersComputer
{
    public long UscoId { get; set; }

    public long CompId { get; set; }

    public long UserId { get; set; }

    public virtual Computer Comp { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
