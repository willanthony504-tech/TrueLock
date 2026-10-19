using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrueLock.API.Models;

[Keyless]
public partial class VwParticipantComputer
{
    [Column("user_id")]
    public long UserId { get; set; }

    [Column("user_names")]
    [StringLength(100)]
    public string UserNames { get; set; } = null!;

    [Column("user_last_names")]
    [StringLength(100)]
    public string UserLastNames { get; set; } = null!;

    [Column("comp_id")]
    public long CompId { get; set; }

    [Column("comp_name")]
    [StringLength(50)]
    public string CompName { get; set; } = null!;

    [Column("comp_status", TypeName = "enum('ACTIVE','INACTIVE')")]
    public string CompStatus { get; set; } = null!;

    [Column("work_id")]
    public long WorkId { get; set; }

    [Column("work_name")]
    [StringLength(35)]
    public string WorkName { get; set; } = null!;
}
