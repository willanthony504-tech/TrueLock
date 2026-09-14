using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrueLock.API.Models;

[Table("institutions")]
[Index("DirectorId", Name = "fk_institutions_director_id_idx")]
[Index("InstEmail", Name = "inst_email_UNIQUE", IsUnique = true)]
public partial class Institution
{
    [Key]
    [Column("inst_id")]
    public long InstId { get; set; }

    [Column("inst_name")]
    [StringLength(50)]
    public string InstName { get; set; } = null!;

    [Column("inst_address")]
    [StringLength(60)]
    public string InstAddress { get; set; } = null!;

    [Column("inst_email")]
    [StringLength(100)]
    public string InstEmail { get; set; } = null!;

    [Column("inst_created_at")]
    [MaxLength(6)]
    public DateTime InstCreatedAt { get; set; }

    [Column("inst_update_at")]
    [MaxLength(6)]
    public DateTime? InstUpdateAt { get; set; }

    [Column("inst_update_by")]
    public long? InstUpdateBy { get; set; }

    [Column("inst_created_by")]
    public long InstCreatedBy { get; set; }

    [Column("director_id")]
    public long DirectorId { get; set; }

    [ForeignKey("DirectorId")]
    [InverseProperty("Institutions")]
    public virtual User Director { get; set; } = null!;

    [InverseProperty("Inst")]
    public virtual ICollection<Headquarter> Headquarters { get; set; } = new List<Headquarter>();
}
