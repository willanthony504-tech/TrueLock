using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrueLock.API.Models;

[Table("users_computers")]
[Index("CompId", Name = "fk_users_computers_comp_id_idx")]
[Index("UserId", Name = "fk_users_computers_user_id_idx")]
[Index("CompId", "UserId", Name = "usco_comp_user_UNIQUE", IsUnique = true)]
public partial class UsersComputer
{
    [Key]
    [Column("usco_id")]
    public long UscoId { get; set; }

    [Column("comp_id")]
    public long CompId { get; set; }

    [Column("user_id")]
    public long UserId { get; set; }

    [ForeignKey("CompId")]
    [InverseProperty("UsersComputers")]
    public virtual Computer Comp { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UsersComputers")]
    public virtual User User { get; set; } = null!;
}
