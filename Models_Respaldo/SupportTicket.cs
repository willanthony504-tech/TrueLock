using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrueLock.API.Models;

[Table("support_tickets")]
[Index("NotiId", Name = "fk_support_tickets_noti_id_idx")]
public partial class SupportTicket
{
    [Key]
    [Column("suti_id")]
    public long SutiId { get; set; }

    [Column("noti_id")]
    public long NotiId { get; set; }

    [Column("suti_created_at")]
    [MaxLength(6)]
    public DateTime SutiCreatedAt { get; set; }

    [Column("suti_created_by")]
    public long SutiCreatedBy { get; set; }

    [Column("suti_priority", TypeName = "enum('LOW','MEDIUM','HIGH')")]
    public string SutiPriority { get; set; } = null!;

    [Column("suti_status", TypeName = "enum('OPEN','IN_PROGRESS','RESOLVED')")]
    public string SutiStatus { get; set; } = null!;

    [ForeignKey("NotiId")]
    [InverseProperty("SupportTickets")]
    public virtual Notification Noti { get; set; } = null!;
}
