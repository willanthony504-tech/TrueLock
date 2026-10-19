using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrueLock.API.Models;

[Table("users_block_configs")]
[Index("AdministradorId", Name = "fk_users_block_configs_administrador_id_idx")]
[Index("BlcoId", Name = "fk_users_block_configs_blco_id_idx")]
public partial class UsersBlockConfig
{
    [Key]
    [Column("usbc_id")]
    public long UsbcId { get; set; }

    [Column("blco_id")]
    public long BlcoId { get; set; }

    [Column("administrador_id")]
    public long AdministradorId { get; set; }

    [ForeignKey("AdministradorId")]
    [InverseProperty("UsersBlockConfigs")]
    public virtual User Administrador { get; set; } = null!;

    [ForeignKey("BlcoId")]
    [InverseProperty("UsersBlockConfigs")]
    public virtual BlockConfig Blco { get; set; } = null!;
}
