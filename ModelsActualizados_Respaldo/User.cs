using System;
using System.Collections.Generic;

namespace TrueLock.API.ModelsActualizados;

public partial class User
{
    public long UserId { get; set; }

    public long RoleId { get; set; }

    public string UserEmail { get; set; } = null!;

    public DateTime UserCreatedAt { get; set; }

    public long UserCreatedBy { get; set; }

    public DateTime? UserUpdateAt { get; set; }

    public long? UserUpdateBy { get; set; }

    public string UserStatus { get; set; } = null!;

    public string UserNames { get; set; } = null!;

    public string UserLastNames { get; set; } = null!;

    public DateOnly UserBirthDate { get; set; }

    public string UserSex { get; set; } = null!;

    public string UserGender { get; set; } = null!;

    public string UserDocumentType { get; set; } = null!;

    public string UserDocumentNumber { get; set; } = null!;

    public string UserPhoneNumber { get; set; } = null!;

    public string UserCountryCode { get; set; } = null!;

    public string? UserProfilePhoto { get; set; }

    public string UserUsername { get; set; } = null!;

    public DateTime? UserPasswordChangedAt { get; set; }

    public string UserPasswordHash { get; set; } = null!;

    public virtual ICollection<Access> Accesses { get; set; } = new List<Access>();

    public virtual ICollection<ActivityLog> ActivityLogs { get; set; } = new List<ActivityLog>();

    public virtual ICollection<Headquarter> HeadquarterAdministradors { get; set; } = new List<Headquarter>();

    public virtual ICollection<Headquarter> HeadquarterDirectors { get; set; } = new List<Headquarter>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();

    public virtual ICollection<Tracing> Tracings { get; set; } = new List<Tracing>();

    public virtual ICollection<UnlockRequest> UnlockRequestAdministradors { get; set; } = new List<UnlockRequest>();

    public virtual ICollection<UnlockRequest> UnlockRequestParticipantes { get; set; } = new List<UnlockRequest>();

    public virtual ICollection<UsersApplication> UsersApplications { get; set; } = new List<UsersApplication>();

    public virtual ICollection<UsersBlockConfig> UsersBlockConfigs { get; set; } = new List<UsersBlockConfig>();

    public virtual ICollection<UsersBlockRule> UsersBlockRules { get; set; } = new List<UsersBlockRule>();

    public virtual ICollection<UsersComputer> UsersComputers { get; set; } = new List<UsersComputer>();

    public virtual ICollection<UsersNotification> UsersNotifications { get; set; } = new List<UsersNotification>();

    public virtual ICollection<UsersWebsite> UsersWebsites { get; set; } = new List<UsersWebsite>();

    public virtual ICollection<UsersWorkspace> UsersWorkspaceAdministradors { get; set; } = new List<UsersWorkspace>();

    public virtual UsersWorkspace? UsersWorkspaceParticipante { get; set; }
}
