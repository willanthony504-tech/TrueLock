using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrueLock.API.Models;

[Table("headquarters")]
[Index("AdministradorId", Name = "fk_headquarters_administrador_id_idx")]
[Index("DirectorId", Name = "fk_headquarters_director_id_idx")]
[Index("InstId", Name = "fk_headquarters_inst_id_idx")]
[Index("HeadEmail", Name = "head_email_UNIQUE", IsUnique = true)]
public partial class Headquarter
{
    [Key]
    [Column("head_id")]
    public long HeadId { get; set; }

    [Column("head_name")]
    [StringLength(50)]
    public string HeadName { get; set; } = null!;

    [Column("head_address")]
    [StringLength(60)]
    public string HeadAddress { get; set; } = null!;

    [Column("head_email")]
    [StringLength(100)]
    public string HeadEmail { get; set; } = null!;

    [Column("head_created_at")]
    [MaxLength(6)]
    public DateTime HeadCreatedAt { get; set; }

    [Column("head_update_at")]
    [MaxLength(6)]
    public DateTime? HeadUpdateAt { get; set; }

    [Column("head_update_by")]
    public long? HeadUpdateBy { get; set; }

    [Column("head_created_by")]
    public long HeadCreatedBy { get; set; }

    [Column("director_id")]
    public long DirectorId { get; set; }

    [Column("administrador_id")]
    public long AdministradorId { get; set; }

    [Column("inst_id")]
    public long InstId { get; set; }

    [ForeignKey("AdministradorId")]
    [InverseProperty("HeadquarterAdministradors")]
    public virtual User Administrador { get; set; } = null!;

    [ForeignKey("DirectorId")]
    [InverseProperty("HeadquarterDirectors")]
    public virtual User Director { get; set; } = null!;

    [ForeignKey("InstId")]
    [InverseProperty("Headquarters")]
    public virtual Institution Inst { get; set; } = null!;

    [InverseProperty("Head")]
    public virtual ICollection<Workspace> Workspaces { get; set; } = new List<Workspace>();
}
