using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrueLock.API.Models;

[Table("notifications")]
public partial class Notification
{
    [Key]
    [Column("noti_id")]
    public long NotiId { get; set; }

    [Column("noti_type", TypeName = "enum('REQUEST','WARNING','SUPPORT')")]
    public string NotiType { get; set; } = null!;

    [Column("noti_title")]
    [StringLength(35)]
    public string NotiTitle { get; set; } = null!;

    [Column("noti_message", TypeName = "text")]
    public string NotiMessage { get; set; } = null!;

    [Column("noti_status", TypeName = "enum('PENDING','REVISED')")]
    public string NotiStatus { get; set; } = null!;

    [Column("noti_created_at")]
    [MaxLength(6)]
    public DateTime NotiCreatedAt { get; set; }

    [Column("noti_created_by")]
    public long NotiCreatedBy { get; set; }

    [InverseProperty("Noti")]
    public virtual ICollection<SupportTicket> SupportTickets { get; set; } = new List<SupportTicket>();

    [InverseProperty("Noti")]
    public virtual ICollection<UsersNotification> UsersNotifications { get; set; } = new List<UsersNotification>();
}
