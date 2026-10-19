using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrueLock.API.Models;

[Table("users")]
[Index("RoleId", Name = "fk_users_role_id_idx")]
[Index("UserDocumentNumber", Name = "user_document_number_UNIQUE", IsUnique = true)]
[Index("UserEmail", Name = "user_email_UNIQUE", IsUnique = true)]
[Index("UserPhoneNumber", Name = "user_phone_number_UNIQUE", IsUnique = true)]
public partial class User
{
    [Key]
    [Column("user_id")]
    public long UserId { get; set; }

    [Column("role_id")]
    public long RoleId { get; set; }

    [Column("user_email")]
    [StringLength(100)]
    public string UserEmail { get; set; } = null!;

    [Column("user_created_at")]
    [MaxLength(6)]
    public DateTime UserCreatedAt { get; set; }

    [Column("user_created_by")]
    public long UserCreatedBy { get; set; }

    [Column("user_update_at")]
    [MaxLength(6)]
    public DateTime? UserUpdateAt { get; set; }

    [Column("user_update_by")]
    public long? UserUpdateBy { get; set; }

    [Column("user_status", TypeName = "enum('ACTIVE','INACTIVE')")]
    public string UserStatus { get; set; } = null!;

    [Column("user_names")]
    [StringLength(100)]
    public string UserNames { get; set; } = null!;

    [Column("user_last_names")]
    [StringLength(100)]
    public string UserLastNames { get; set; } = null!;

    [Column("user_birth_date")]
    public DateOnly UserBirthDate { get; set; }

    [Column("user_sex", TypeName = "enum('MALE','FEMALE','OTHER','PREFER_NOT_TO_SAY')")]
    public string UserSex { get; set; } = null!;

    [Column("user_gender", TypeName = "enum('MAN','WOMAN','OTHER','PREFER_NOT_TO_SAY')")]
    public string UserGender { get; set; } = null!;

    [Column("user_document_type", TypeName = "enum('P.P','C.C','P.P.T','T.I','OTHER')")]
    public string UserDocumentType { get; set; } = null!;

    [Column("user_document_number")]
    [StringLength(40)]
    public string UserDocumentNumber { get; set; } = null!;

    [Column("user_phone_number")]
    [StringLength(20)]
    public string UserPhoneNumber { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<Access> Accesses { get; set; } = new List<Access>();

    [InverseProperty("Participante")]
    public virtual ICollection<ActivityLog> ActivityLogs { get; set; } = new List<ActivityLog>();

    [InverseProperty("Administrador")]
    public virtual ICollection<Headquarter> HeadquarterAdministradors { get; set; } = new List<Headquarter>();

    [InverseProperty("Director")]
    public virtual ICollection<Headquarter> HeadquarterDirectors { get; set; } = new List<Headquarter>();

    [InverseProperty("Director")]
    public virtual ICollection<Institution> Institutions { get; set; } = new List<Institution>();

    [ForeignKey("RoleId")]
    [InverseProperty("Users")]
    public virtual Role Role { get; set; } = null!;

    [InverseProperty("Participante")]
    public virtual ICollection<Tracing> Tracings { get; set; } = new List<Tracing>();

    [InverseProperty("Administrador")]
    public virtual ICollection<UnlockRequest> UnlockRequestAdministradors { get; set; } = new List<UnlockRequest>();

    [InverseProperty("Participante")]
    public virtual ICollection<UnlockRequest> UnlockRequestParticipantes { get; set; } = new List<UnlockRequest>();

    [InverseProperty("Administrador")]
    public virtual ICollection<UsersBlockConfig> UsersBlockConfigs { get; set; } = new List<UsersBlockConfig>();

    [InverseProperty("Administrador")]
    public virtual ICollection<UsersBlockRule> UsersBlockRules { get; set; } = new List<UsersBlockRule>();

    [InverseProperty("User")]
    public virtual ICollection<UsersComputer> UsersComputers { get; set; } = new List<UsersComputer>();

    [InverseProperty("User")]
    public virtual ICollection<UsersNotification> UsersNotifications { get; set; } = new List<UsersNotification>();

    [InverseProperty("Administrador")]
    public virtual ICollection<UsersWorkspace> UsersWorkspaceAdministradors { get; set; } = new List<UsersWorkspace>();

    [InverseProperty("Participante")]
    public virtual UsersWorkspace? UsersWorkspaceParticipante { get; set; }
}
