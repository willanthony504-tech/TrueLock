using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrueLock.API.Models;

[Table("users_notifications")]
[Index("NotiId", Name = "fk_users_notifications_noti_id_idx")]
[Index("UserId", Name = "fk_users_notifications_user_id_idx")]
[Index("UserId", "NotiId", Name = "user_noti_UNIQUE", IsUnique = true)]
public partial class UsersNotification
{
    [Key]
    [Column("usno_id")]
    public long UsnoId { get; set; }

    [Column("user_id")]
    public long UserId { get; set; }

    [Column("noti_id")]
    public long NotiId { get; set; }

    [ForeignKey("NotiId")]
    [InverseProperty("UsersNotifications")]
    public virtual Notification Noti { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UsersNotifications")]
    public virtual User User { get; set; } = null!;
}
