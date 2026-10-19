using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrueLock.API.Models;

[Table("users_block_rules")]
[Index("AdministradorId", Name = "fk_users_block_rules_administrador_id_idx")]
[Index("BlruId", Name = "fk_users_block_rules_blru_id_idx")]
public partial class UsersBlockRule
{
    [Key]
    [Column("usbr_id")]
    public long UsbrId { get; set; }

    [Column("blru_id")]
    public long BlruId { get; set; }

    [Column("administrador_id")]
    public long AdministradorId { get; set; }

    [ForeignKey("AdministradorId")]
    [InverseProperty("UsersBlockRules")]
    public virtual User Administrador { get; set; } = null!;

    [ForeignKey("BlruId")]
    [InverseProperty("UsersBlockRules")]
    public virtual BlockRule Blru { get; set; } = null!;
}
