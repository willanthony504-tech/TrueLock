using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TrueLock.API.ModelsActualizados;

public partial class TrueLockDbContext : DbContext
{
    public TrueLockDbContext(DbContextOptions<TrueLockDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Access> Accesses { get; set; }

    public virtual DbSet<ActivityLog> ActivityLogs { get; set; }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<BlockConfig> BlockConfigs { get; set; }

    public virtual DbSet<BlockConfigsBlockRule> BlockConfigsBlockRules { get; set; }

    public virtual DbSet<BlockRule> BlockRules { get; set; }

    public virtual DbSet<BlockRulesUnlockRequest> BlockRulesUnlockRequests { get; set; }

    public virtual DbSet<Computer> Computers { get; set; }

    public virtual DbSet<Headquarter> Headquarters { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Plan> Plans { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }

    public virtual DbSet<SupportTicket> SupportTickets { get; set; }

    public virtual DbSet<Tracing> Tracings { get; set; }

    public virtual DbSet<UnlockRequest> UnlockRequests { get; set; }

    public virtual DbSet<UnlockRequestsComputer> UnlockRequestsComputers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersApplication> UsersApplications { get; set; }

    public virtual DbSet<UsersBlockConfig> UsersBlockConfigs { get; set; }

    public virtual DbSet<UsersBlockRule> UsersBlockRules { get; set; }

    public virtual DbSet<UsersComputer> UsersComputers { get; set; }

    public virtual DbSet<UsersNotification> UsersNotifications { get; set; }

    public virtual DbSet<UsersWebsite> UsersWebsites { get; set; }

    public virtual DbSet<UsersWorkspace> UsersWorkspaces { get; set; }

    public virtual DbSet<Website> Websites { get; set; }

    public virtual DbSet<Workspace> Workspaces { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_unicode_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Access>(entity =>
        {
            entity.HasKey(e => e.AcceId).HasName("PRIMARY");

            entity.ToTable("accesses");

            entity.HasIndex(e => e.PermId, "fk_access_perm_id_idx");

            entity.HasIndex(e => e.UserId, "fk_accesses_user_id_idx");

            entity.Property(e => e.AcceId).HasColumnName("acce_id");
            entity.Property(e => e.AcceCreatedAt)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("acce_created_at");
            entity.Property(e => e.AcceCreatedBy).HasColumnName("acce_created_by");
            entity.Property(e => e.AcceDescription)
                .HasColumnType("text")
                .HasColumnName("acce_description");
            entity.Property(e => e.AcceFailedAttempts).HasColumnName("acce_failed_attempts");
            entity.Property(e => e.AcceLastLoginAt)
                .HasMaxLength(6)
                .HasColumnName("acce_last_login_at");
            entity.Property(e => e.AcceLockedUntil)
                .HasMaxLength(6)
                .HasColumnName("acce_locked_until");
            entity.Property(e => e.AcceUpdateAt)
                .HasMaxLength(6)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("acce_update_at");
            entity.Property(e => e.AcceUpdateBy).HasColumnName("acce_update_by");
            entity.Property(e => e.PermId).HasColumnName("perm_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Perm).WithMany(p => p.Accesses)
                .HasForeignKey(d => d.PermId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_access_perm_id");

            entity.HasOne(d => d.User).WithMany(p => p.Accesses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_accesses_user_id");
        });

        modelBuilder.Entity<ActivityLog>(entity =>
        {
            entity.HasKey(e => e.AcloId).HasName("PRIMARY");

            entity.ToTable("activity_logs");

            entity.HasIndex(e => e.CompId, "fk_activity_logs_comp_id_idx");

            entity.HasIndex(e => e.ParticipanteId, "fk_activity_logs_participante_id_idx");

            entity.Property(e => e.AcloId).HasColumnName("aclo_id");
            entity.Property(e => e.AcloAction)
                .HasColumnType("enum('BLOCKED','ALLOWED')")
                .HasColumnName("aclo_action");
            entity.Property(e => e.AcloCreatedAt)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("aclo_created_at");
            entity.Property(e => e.AcloCreatedBy).HasColumnName("aclo_created_by");
            entity.Property(e => e.AcloDescription)
                .HasColumnType("text")
                .HasColumnName("aclo_description");
            entity.Property(e => e.AcloResource)
                .HasColumnType("text")
                .HasColumnName("aclo_resource");
            entity.Property(e => e.AcloType)
                .HasColumnType("enum('SOFTWARE','WEB')")
                .HasColumnName("aclo_type");
            entity.Property(e => e.CompId).HasColumnName("comp_id");
            entity.Property(e => e.ParticipanteId).HasColumnName("participante_id");

            entity.HasOne(d => d.Comp).WithMany(p => p.ActivityLogs)
                .HasForeignKey(d => d.CompId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_activity_logs_comp_id");

            entity.HasOne(d => d.Participante).WithMany(p => p.ActivityLogs)
                .HasForeignKey(d => d.ParticipanteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_activity_logs_participante_id");
        });

        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.ApplId).HasName("PRIMARY");

            entity.ToTable("applications");

            entity.HasIndex(e => e.ApplName, "appl_name_UNIQUE").IsUnique();

            entity.Property(e => e.ApplId).HasColumnName("appl_id");
            entity.Property(e => e.ApplCreatedAt)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("appl_created_at");
            entity.Property(e => e.ApplCreatedBy).HasColumnName("appl_created_by");
            entity.Property(e => e.ApplExecutablePath)
                .HasMaxLength(700)
                .HasColumnName("appl_executable_path");
            entity.Property(e => e.ApplImagePath)
                .HasMaxLength(500)
                .HasColumnName("appl_image_path");
            entity.Property(e => e.ApplName)
                .HasMaxLength(50)
                .HasColumnName("appl_name");
            entity.Property(e => e.ApplStatus)
                .HasDefaultValueSql("'UNBLOCKED'")
                .HasColumnType("enum('BLOCKED','UNBLOCKED')")
                .HasColumnName("appl_status");
            entity.Property(e => e.ApplUpdateAt)
                .HasMaxLength(6)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("appl_update_at");
            entity.Property(e => e.ApplUpdateBy).HasColumnName("appl_update_by");
        });

        modelBuilder.Entity<BlockConfig>(entity =>
        {
            entity.HasKey(e => e.BlcoId).HasName("PRIMARY");

            entity.ToTable("block_configs");

            entity.Property(e => e.BlcoId).HasColumnName("blco_id");
            entity.Property(e => e.BlcoCreatedAt)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("blco_created_at");
            entity.Property(e => e.BlcoCreatedBy).HasColumnName("blco_created_by");
            entity.Property(e => e.BlcoDescription)
                .HasColumnType("text")
                .HasColumnName("blco_description");
            entity.Property(e => e.BlcoName)
                .HasMaxLength(35)
                .HasColumnName("blco_name");
            entity.Property(e => e.BlcoUpdateAt)
                .HasMaxLength(6)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("blco_update_at");
            entity.Property(e => e.BlcoUpdateBy).HasColumnName("blco_update_by");
        });

        modelBuilder.Entity<BlockConfigsBlockRule>(entity =>
        {
            entity.HasKey(e => e.BlblId).HasName("PRIMARY");

            entity.ToTable("block_configs_block_rules");

            entity.HasIndex(e => new { e.BlcoId, e.BlruId }, "blco_blru_UNIQUE").IsUnique();

            entity.HasIndex(e => e.BlcoId, "fk_block_configs_block_rules_blco_id_idx");

            entity.HasIndex(e => e.BlruId, "fk_block_configs_block_rules_blru_id_id_idx");

            entity.Property(e => e.BlblId).HasColumnName("blbl_id");
            entity.Property(e => e.BlcoId).HasColumnName("blco_id");
            entity.Property(e => e.BlruId).HasColumnName("blru_id");

            entity.HasOne(d => d.Blco).WithMany(p => p.BlockConfigsBlockRules)
                .HasForeignKey(d => d.BlcoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_block_configs_block_rules_blco_id");

            entity.HasOne(d => d.Blru).WithMany(p => p.BlockConfigsBlockRules)
                .HasForeignKey(d => d.BlruId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_block_configs_block_rules_blru_id");
        });

        modelBuilder.Entity<BlockRule>(entity =>
        {
            entity.HasKey(e => e.BlruId).HasName("PRIMARY");

            entity.ToTable("block_rules");

            entity.HasIndex(e => e.BlruName, "blru_name_UNIQUE").IsUnique();

            entity.Property(e => e.BlruId).HasColumnName("blru_id");
            entity.Property(e => e.BlruCreatedAt)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("blru_created_at");
            entity.Property(e => e.BlruCreatedBy).HasColumnName("blru_created_by");
            entity.Property(e => e.BlruDescription)
                .HasColumnType("text")
                .HasColumnName("blru_description");
            entity.Property(e => e.BlruName)
                .HasMaxLength(40)
                .HasColumnName("blru_name");
            entity.Property(e => e.BlruPatron)
                .HasColumnType("enum('BLOCKED','ALLOWED')")
                .HasColumnName("blru_patron");
            entity.Property(e => e.BlruType)
                .HasColumnType("enum('SOFTWARE','WEB')")
                .HasColumnName("blru_type");
            entity.Property(e => e.BlruUpdateAt)
                .HasMaxLength(6)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("blru_update_at");
            entity.Property(e => e.BlruUpdateBy).HasColumnName("blru_update_by");
        });

        modelBuilder.Entity<BlockRulesUnlockRequest>(entity =>
        {
            entity.HasKey(e => e.BlunId).HasName("PRIMARY");

            entity.ToTable("block_rules_unlock_requests");

            entity.HasIndex(e => e.BlruId, "fk_block_rules_unlock_requests_blru_id_idx");

            entity.HasIndex(e => e.UnreId, "fk_block_rules_unlock_requests_unre_id_id_idx");

            entity.Property(e => e.BlunId).HasColumnName("blun_id");
            entity.Property(e => e.BlruId).HasColumnName("blru_id");
            entity.Property(e => e.UnreId).HasColumnName("unre_id");

            entity.HasOne(d => d.Blru).WithMany(p => p.BlockRulesUnlockRequests)
                .HasForeignKey(d => d.BlruId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_block_rules_unlock_requests_blru_id");

            entity.HasOne(d => d.Unre).WithMany(p => p.BlockRulesUnlockRequests)
                .HasForeignKey(d => d.UnreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_block_rules_unlock_requests_unre_id");
        });

        modelBuilder.Entity<Computer>(entity =>
        {
            entity.HasKey(e => e.CompId).HasName("PRIMARY");

            entity.ToTable("computers");

            entity.HasIndex(e => e.WorkId, "fk_computers_work_id_idx");

            entity.Property(e => e.CompId).HasColumnName("comp_id");
            entity.Property(e => e.CompCreatedAt)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("comp_created_at");
            entity.Property(e => e.CompName)
                .HasMaxLength(50)
                .HasColumnName("comp_name");
            entity.Property(e => e.CompStatus)
                .HasColumnType("enum('ACTIVE','INACTIVE')")
                .HasColumnName("comp_status");
            entity.Property(e => e.CompUpdateAt)
                .HasMaxLength(6)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("comp_update_at");
            entity.Property(e => e.CompUpdateBy).HasColumnName("comp_update_by");
            entity.Property(e => e.WorkId).HasColumnName("work_id");

            entity.HasOne(d => d.Work).WithMany(p => p.Computers)
                .HasForeignKey(d => d.WorkId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_computers_work_id");
        });

        modelBuilder.Entity<Headquarter>(entity =>
        {
            entity.HasKey(e => e.HeadId).HasName("PRIMARY");

            entity.ToTable("headquarters");

            entity.HasIndex(e => e.AdministradorId, "fk_headquarters_administrador_id_idx");

            entity.HasIndex(e => e.DirectorId, "fk_headquarters_director_id_idx");

            entity.HasIndex(e => e.HeadEmail, "head_email_UNIQUE").IsUnique();

            entity.Property(e => e.HeadId).HasColumnName("head_id");
            entity.Property(e => e.AdministradorId).HasColumnName("administrador_id");
            entity.Property(e => e.DirectorId).HasColumnName("director_id");
            entity.Property(e => e.HeadAddress)
                .HasMaxLength(60)
                .HasColumnName("head_address");
            entity.Property(e => e.HeadCreatedAt)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("head_created_at");
            entity.Property(e => e.HeadCreatedBy).HasColumnName("head_created_by");
            entity.Property(e => e.HeadEmail)
                .HasMaxLength(100)
                .HasColumnName("head_email");
            entity.Property(e => e.HeadInstitutionsBelong)
                .HasMaxLength(250)
                .HasColumnName("head_institutions_belong");
            entity.Property(e => e.HeadName)
                .HasMaxLength(50)
                .HasColumnName("head_name");
            entity.Property(e => e.HeadUpdateAt)
                .HasMaxLength(6)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("head_update_at");
            entity.Property(e => e.HeadUpdateBy).HasColumnName("head_update_by");

            entity.HasOne(d => d.Administrador).WithMany(p => p.HeadquarterAdministradors)
                .HasForeignKey(d => d.AdministradorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_headquarters_administrador_id");

            entity.HasOne(d => d.Director).WithMany(p => p.HeadquarterDirectors)
                .HasForeignKey(d => d.DirectorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_headquarters_director_id");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotiId).HasName("PRIMARY");

            entity.ToTable("notifications");

            entity.Property(e => e.NotiId).HasColumnName("noti_id");
            entity.Property(e => e.NotiCreatedAt)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("noti_created_at");
            entity.Property(e => e.NotiCreatedBy).HasColumnName("noti_created_by");
            entity.Property(e => e.NotiMessage)
                .HasColumnType("text")
                .HasColumnName("noti_message");
            entity.Property(e => e.NotiStatus)
                .HasColumnType("enum('PENDING','REVISED')")
                .HasColumnName("noti_status");
            entity.Property(e => e.NotiTitle)
                .HasMaxLength(35)
                .HasColumnName("noti_title");
            entity.Property(e => e.NotiType)
                .HasColumnType("enum('REQUEST','WARNING','SUPPORT')")
                .HasColumnName("noti_type");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymId).HasName("PRIMARY");

            entity.ToTable("payments");

            entity.HasIndex(e => e.SubsId, "fk_payments_subs_id_idx");

            entity.Property(e => e.PaymId)
                .ValueGeneratedNever()
                .HasColumnName("paym_id");
            entity.Property(e => e.PaymAmount)
                .HasPrecision(10, 2)
                .HasColumnName("paym_amount");
            entity.Property(e => e.PaymCreatedAt)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("paym_created_at");
            entity.Property(e => e.PaymCurrency)
                .HasMaxLength(3)
                .HasDefaultValueSql("'DLS'")
                .IsFixedLength()
                .HasColumnName("paym_currency");
            entity.Property(e => e.PaymDescription)
                .HasColumnType("text")
                .HasColumnName("paym_description");
            entity.Property(e => e.PaymPaidAt)
                .HasMaxLength(6)
                .HasColumnName("paym_paid_at");
            entity.Property(e => e.PaymPaymentMethod)
                .HasColumnType("enum('CARD','BANK_TRANSFER','OTHER')")
                .HasColumnName("paym_payment_method");
            entity.Property(e => e.PaymReference)
                .HasMaxLength(100)
                .HasColumnName("paym_reference");
            entity.Property(e => e.PaymStatus)
                .HasDefaultValueSql("'PENDING'")
                .HasColumnType("enum('PENDING','APPROVED','REJECTED','REFUNDED')")
                .HasColumnName("paym_status");
            entity.Property(e => e.SubsId).HasColumnName("subs_id");

            entity.HasOne(d => d.Subs).WithMany(p => p.Payments)
                .HasForeignKey(d => d.SubsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_payments_subs_id");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.PermId).HasName("PRIMARY");

            entity.ToTable("permissions");

            entity.HasIndex(e => e.PermCode, "perm_code_UNIQUE").IsUnique();

            entity.HasIndex(e => e.PermName, "perm_name_UNIQUE").IsUnique();

            entity.Property(e => e.PermId).HasColumnName("perm_id");
            entity.Property(e => e.PermCode)
                .HasMaxLength(30)
                .HasColumnName("perm_code");
            entity.Property(e => e.PermCreatedAt)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("perm_created_at");
            entity.Property(e => e.PermCreatedBy).HasColumnName("perm_created_by");
            entity.Property(e => e.PermDescription)
                .HasColumnType("text")
                .HasColumnName("perm_description");
            entity.Property(e => e.PermName)
                .HasMaxLength(30)
                .HasColumnName("perm_name");
            entity.Property(e => e.PermUpdateAt)
                .HasMaxLength(6)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("perm_update_at");
            entity.Property(e => e.PermUpdateBy).HasColumnName("perm_update_by");
        });

        modelBuilder.Entity<Plan>(entity =>
        {
            entity.HasKey(e => e.PlanId).HasName("PRIMARY");

            entity.ToTable("plans");

            entity.HasIndex(e => e.PlanName, "plan_name_UNIQUE").IsUnique();

            entity.Property(e => e.PlanId).HasColumnName("plan_id");
            entity.Property(e => e.PlanCreatedAt)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("plan_created_at");
            entity.Property(e => e.PlanCreatedBy).HasColumnName("plan_created_by");
            entity.Property(e => e.PlanDescription)
                .HasColumnType("text")
                .HasColumnName("plan_description");
            entity.Property(e => e.PlanDurationsDays).HasColumnName("plan_durations_days");
            entity.Property(e => e.PlanMaxComputers).HasColumnName("plan_max_computers");
            entity.Property(e => e.PlanName)
                .HasMaxLength(45)
                .HasColumnName("plan_name");
            entity.Property(e => e.PlanPrice)
                .HasPrecision(10, 2)
                .HasColumnName("plan_price");
            entity.Property(e => e.PlanStatus)
                .HasDefaultValueSql("'ACTIVE'")
                .HasColumnType("enum('ACTIVE','INACTIVE')")
                .HasColumnName("plan_status");
            entity.Property(e => e.PlanUpdateAt)
                .HasMaxLength(6)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("plan_update at");
            entity.Property(e => e.PlanUpdateBy).HasColumnName("plan_update_by");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.HasIndex(e => e.RoleCode, "role_code_UNIQUE").IsUnique();

            entity.HasIndex(e => e.RoleName, "role_name_UNIQUE").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleCode)
                .HasMaxLength(30)
                .HasColumnName("role_code");
            entity.Property(e => e.RoleCreatedAt)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("role_created_at");
            entity.Property(e => e.RoleCreatedBy).HasColumnName("role_created_by");
            entity.Property(e => e.RoleDescription)
                .HasColumnType("text")
                .HasColumnName("role_description");
            entity.Property(e => e.RoleName)
                .HasColumnType("enum('DIRECTOR','ADMINISTRADOR','PARTICIPANTE')")
                .HasColumnName("role_name");
            entity.Property(e => e.RoleUpdateAt)
                .HasMaxLength(6)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("role_update_at");
            entity.Property(e => e.RoleUpdateBy).HasColumnName("role_update_by");
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(e => e.RopeId).HasName("PRIMARY");

            entity.ToTable("role_permissions");

            entity.HasIndex(e => e.PermId, "fk_role_permissions_perm_id_idx");

            entity.HasIndex(e => e.RoleId, "fk_role_permissions_role_id_idx");

            entity.HasIndex(e => new { e.RoleId, e.PermId }, "role_perm_UNIQUE").IsUnique();

            entity.Property(e => e.RopeId).HasColumnName("rope_id");
            entity.Property(e => e.PermId).HasColumnName("perm_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Perm).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.PermId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_role_permissions_perm_id");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_role_permissions_role_id");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.ScheId).HasName("PRIMARY");

            entity.ToTable("schedules");

            entity.Property(e => e.ScheId).HasColumnName("sche_id");
            entity.Property(e => e.ScheEndTime)
                .HasColumnType("time")
                .HasColumnName("sche_end_time");
            entity.Property(e => e.ScheStartTime)
                .HasColumnType("time")
                .HasColumnName("sche_start_time");
            entity.Property(e => e.ScheDays)
                .HasColumnType("set('MONDAY','TUESDAY','WEDNESDAY','THURSDAY','FRIDAY','SATURDAY','SUNDAY')")
                .HasColumnName("sche_days");
            entity.Property(e => e.ScheStatus)
                .HasDefaultValueSql("'INACTIVE'")
                .HasColumnType("enum('ACTIVE','INACTIVE')")
                .HasColumnName("sche_status");
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.HasKey(e => e.SubsId).HasName("PRIMARY");

            entity.ToTable("subscriptions");

            entity.HasIndex(e => e.PlanId, "fk_subscriptions_plan_id_idx");

            entity.HasIndex(e => e.DirectorId, "fk_subscriptions_users1_idx");

            entity.Property(e => e.SubsId).HasColumnName("subs_id");
            entity.Property(e => e.DirectorId).HasColumnName("director_id");
            entity.Property(e => e.PlanId).HasColumnName("plan_id");
            entity.Property(e => e.SubsCreatedAt)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("subs_created_at");
            entity.Property(e => e.SubsEndDate)
                .HasMaxLength(6)
                .HasColumnName("subs_end_date");
            entity.Property(e => e.SubsStartDate)
                .HasMaxLength(6)
                .HasColumnName("subs_start_date");
            entity.Property(e => e.SubsStatus)
                .HasDefaultValueSql("'ACTIVE'")
                .HasColumnType("enum('ACTIVE','EXPIRED','CANCELLED')")
                .HasColumnName("subs_status");

            entity.HasOne(d => d.Director).WithMany(p => p.Subscriptions)
                .HasForeignKey(d => d.DirectorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_subscriptions_director_id");

            entity.HasOne(d => d.Plan).WithMany(p => p.Subscriptions)
                .HasForeignKey(d => d.PlanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_subscriptions_plan_id");
        });

        modelBuilder.Entity<SupportTicket>(entity =>
        {
            entity.HasKey(e => e.SutiId).HasName("PRIMARY");

            entity.ToTable("support_tickets");

            entity.HasIndex(e => e.NotiId, "fk_support_tickets_noti_id_idx");

            entity.Property(e => e.SutiId).HasColumnName("suti_id");
            entity.Property(e => e.NotiId).HasColumnName("noti_id");
            entity.Property(e => e.SutiCreatedAt)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("suti_created_at");
            entity.Property(e => e.SutiCreatedBy).HasColumnName("suti_created_by");
            entity.Property(e => e.SutiPriority)
                .HasColumnType("enum('LOW','MEDIUM','HIGH')")
                .HasColumnName("suti_priority");
            entity.Property(e => e.SutiResponseDate)
                .HasMaxLength(6)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("suti_response_date");
            entity.Property(e => e.SutiStatus)
                .HasColumnType("enum('OPEN','IN_PROGRESS','RESOLVED')")
                .HasColumnName("suti_status");

            entity.HasOne(d => d.Noti).WithMany(p => p.SupportTickets)
                .HasForeignKey(d => d.NotiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_support_tickets_noti_id");
        });

        modelBuilder.Entity<Tracing>(entity =>
        {
            entity.HasKey(e => e.TracId).HasName("PRIMARY");

            entity.ToTable("tracing");

            entity.HasIndex(e => e.ParticipanteId, "fk_tracing_participante_id_idx");

            entity.Property(e => e.TracId).HasColumnName("trac_id");
            entity.Property(e => e.ParticipanteId).HasColumnName("participante_id");
            entity.Property(e => e.TracCreatedAt)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("trac_created_at");
            entity.Property(e => e.TracCreatedBy).HasColumnName("trac_created_by");
            entity.Property(e => e.TracName)
                .HasColumnType("enum('ACTIVITY_LOGS','SUPPORT','UNLOCK_REQUEST')")
                .HasColumnName("trac_name");
            entity.Property(e => e.TracUpdateAt)
                .HasMaxLength(6)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("trac_update_at");
            entity.Property(e => e.TracUpdateBy).HasColumnName("trac_update_by");

            entity.HasOne(d => d.Participante).WithMany(p => p.Tracings)
                .HasForeignKey(d => d.ParticipanteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tracing_participante_id");
        });

        modelBuilder.Entity<UnlockRequest>(entity =>
        {
            entity.HasKey(e => e.UnreId).HasName("PRIMARY");

            entity.ToTable("unlock_requests");

            entity.HasIndex(e => e.AdministradorId, "fk_unlock_requests_administrador_id_idx");

            entity.HasIndex(e => e.ParticipanteId, "fk_unlock_requests_participante_id_idx");

            entity.Property(e => e.UnreId).HasColumnName("unre_id");
            entity.Property(e => e.AdministradorId).HasColumnName("administrador_id");
            entity.Property(e => e.ParticipanteId).HasColumnName("participante_id");
            entity.Property(e => e.UnreCreatedAt)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("unre_created_at");
            entity.Property(e => e.UnreCreatedBy).HasColumnName("unre_created_by");
            entity.Property(e => e.UnreReason)
                .HasColumnType("text")
                .HasColumnName("unre_reason");
            entity.Property(e => e.UnreResponseDate)
                .HasMaxLength(6)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("unre_response_date");
            entity.Property(e => e.UnreStatus)
                .HasColumnType("enum('PENDING','APPROVED','REJECTED')")
                .HasColumnName("unre_status");
            entity.Property(e => e.UnreUpdateAt)
                .HasMaxLength(6)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("unre_update_at");
            entity.Property(e => e.UnreUpdateBy).HasColumnName("unre_update_by");

            entity.HasOne(d => d.Administrador).WithMany(p => p.UnlockRequestAdministradors)
                .HasForeignKey(d => d.AdministradorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_unlock_requests_administrador_id");

            entity.HasOne(d => d.Participante).WithMany(p => p.UnlockRequestParticipantes)
                .HasForeignKey(d => d.ParticipanteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_unlock_requests_participante_id");
        });

        modelBuilder.Entity<UnlockRequestsComputer>(entity =>
        {
            entity.HasKey(e => e.UncoId).HasName("PRIMARY");

            entity.ToTable("unlock_requests_computers");

            entity.HasIndex(e => e.CompId, "fk_unlock_requests_computers_comp_id_idx");

            entity.HasIndex(e => e.UnreId, "fk_unlock_requests_computers_unre_id_idx");

            entity.HasIndex(e => new { e.CompId, e.UnreId }, "unco_comp_unre_UNIQUE").IsUnique();

            entity.Property(e => e.UncoId).HasColumnName("unco_id");
            entity.Property(e => e.CompId).HasColumnName("comp_id");
            entity.Property(e => e.UnreId).HasColumnName("unre_id");

            entity.HasOne(d => d.Comp).WithMany(p => p.UnlockRequestsComputers)
                .HasForeignKey(d => d.CompId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_unlock_requests_computers_comp_id");

            entity.HasOne(d => d.Unre).WithMany(p => p.UnlockRequestsComputers)
                .HasForeignKey(d => d.UnreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_unlock_requests_computers_unre_id");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.RoleId, "fk_users_role_id_idx");

            entity.HasIndex(e => e.UserDocumentNumber, "user_document_number_UNIQUE").IsUnique();

            entity.HasIndex(e => e.UserEmail, "user_email_UNIQUE").IsUnique();

            entity.HasIndex(e => e.UserPhoneNumber, "user_phone_number_UNIQUE").IsUnique();

            entity.HasIndex(e => e.UserUsername, "user_username_UNIQUE").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UserBirthDate).HasColumnName("user_birth_date");
            entity.Property(e => e.UserCountryCode)
                .HasMaxLength(6)
                .HasDefaultValueSql("'+57'")
                .HasColumnName("user_country_code");
            entity.Property(e => e.UserCreatedAt)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("user_created_at");
            entity.Property(e => e.UserCreatedBy).HasColumnName("user_created_by");
            entity.Property(e => e.UserDocumentNumber)
                .HasMaxLength(40)
                .HasColumnName("user_document_number");
            entity.Property(e => e.UserDocumentType)
                .HasColumnType("enum('P.P','C.C','P.P.T','T.I','OTHER')")
                .HasColumnName("user_document_type");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(100)
                .HasColumnName("user_email");
            entity.Property(e => e.UserGender)
                .HasColumnType("enum('MAN','WOMAN','OTHER','PREFER_NOT_TO_SAY')")
                .HasColumnName("user_gender");
            entity.Property(e => e.UserLastNames)
                .HasMaxLength(100)
                .HasColumnName("user_last_names");
            entity.Property(e => e.UserNames)
                .HasMaxLength(100)
                .HasColumnName("user_names");
            entity.Property(e => e.UserPasswordChangedAt)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("user_password_changed_at");
            entity.Property(e => e.UserPasswordHash)
                .HasMaxLength(255)
                .HasColumnName("user_password_hash");
            entity.Property(e => e.UserPhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("user_phone_number");
            entity.Property(e => e.UserProfilePhoto)
                .HasMaxLength(450)
                .HasColumnName("user_profile_photo");
            entity.Property(e => e.UserSex)
                .HasColumnType("enum('MALE','FEMALE','OTHER','PREFER_NOT_TO_SAY')")
                .HasColumnName("user_sex");
            entity.Property(e => e.UserStatus)
                .HasDefaultValueSql("'ACTIVE'")
                .HasColumnType("enum('ACTIVE','INACTIVE')")
                .HasColumnName("user_status");
            entity.Property(e => e.UserUpdateAt)
                .HasMaxLength(6)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("user_update_at");
            entity.Property(e => e.UserUpdateBy).HasColumnName("user_update_by");
            entity.Property(e => e.UserUsername)
                .HasMaxLength(40)
                .HasColumnName("user_username");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_role_id");
        });

        modelBuilder.Entity<UsersApplication>(entity =>
        {
            entity.HasKey(e => e.UsapId).HasName("PRIMARY");

            entity.ToTable("users_applications");

            entity.HasIndex(e => e.ApplId, "fk_users_applications_application");

            entity.HasIndex(e => new { e.AdministradorId, e.ApplId }, "usap_user_appl_UNIQUE").IsUnique();

            entity.Property(e => e.UsapId).HasColumnName("usap_id");
            entity.Property(e => e.AdministradorId).HasColumnName("administrador_id");
            entity.Property(e => e.ApplId).HasColumnName("appl_id");

            entity.HasOne(d => d.Administrador).WithMany(p => p.UsersApplications)
                .HasForeignKey(d => d.AdministradorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_applications_user");

            entity.HasOne(d => d.Appl).WithMany(p => p.UsersApplications)
                .HasForeignKey(d => d.ApplId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_applications_application");
        });

        modelBuilder.Entity<UsersBlockConfig>(entity =>
        {
            entity.HasKey(e => e.UsbcId).HasName("PRIMARY");

            entity.ToTable("users_block_configs");

            entity.HasIndex(e => e.AdministradorId, "fk_users_block_configs_administrador_id_idx");

            entity.HasIndex(e => e.BlcoId, "fk_users_block_configs_blco_id_idx");

            entity.Property(e => e.UsbcId).HasColumnName("usbc_id");
            entity.Property(e => e.AdministradorId).HasColumnName("administrador_id");
            entity.Property(e => e.BlcoId).HasColumnName("blco_id");

            entity.HasOne(d => d.Administrador).WithMany(p => p.UsersBlockConfigs)
                .HasForeignKey(d => d.AdministradorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_block_configs_administrador_id");

            entity.HasOne(d => d.Blco).WithMany(p => p.UsersBlockConfigs)
                .HasForeignKey(d => d.BlcoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_block_configs_blco_id");
        });

        modelBuilder.Entity<UsersBlockRule>(entity =>
        {
            entity.HasKey(e => e.UsbrId).HasName("PRIMARY");

            entity.ToTable("users_block_rules");

            entity.HasIndex(e => e.AdministradorId, "fk_users_block_rules_administrador_id_idx");

            entity.HasIndex(e => e.BlruId, "fk_users_block_rules_blru_id_idx");

            entity.Property(e => e.UsbrId).HasColumnName("usbr_id");
            entity.Property(e => e.AdministradorId).HasColumnName("administrador_id");
            entity.Property(e => e.BlruId).HasColumnName("blru_id");

            entity.HasOne(d => d.Administrador).WithMany(p => p.UsersBlockRules)
                .HasForeignKey(d => d.AdministradorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_block_rules_administrador_id");

            entity.HasOne(d => d.Blru).WithMany(p => p.UsersBlockRules)
                .HasForeignKey(d => d.BlruId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_block_rules_blru_id");
        });

        modelBuilder.Entity<UsersComputer>(entity =>
        {
            entity.HasKey(e => e.UscoId).HasName("PRIMARY");

            entity.ToTable("users_computers");

            entity.HasIndex(e => e.CompId, "fk_users_computers_comp_id_idx");

            entity.HasIndex(e => e.UserId, "fk_users_computers_user_id_idx");

            entity.HasIndex(e => new { e.CompId, e.UserId }, "usco_comp_user_UNIQUE").IsUnique();

            entity.Property(e => e.UscoId).HasColumnName("usco_id");
            entity.Property(e => e.CompId).HasColumnName("comp_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Comp).WithMany(p => p.UsersComputers)
                .HasForeignKey(d => d.CompId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_computers_comp_id");

            entity.HasOne(d => d.User).WithMany(p => p.UsersComputers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_computers_user_id");
        });

        modelBuilder.Entity<UsersNotification>(entity =>
        {
            entity.HasKey(e => e.UsnoId).HasName("PRIMARY");

            entity.ToTable("users_notifications");

            entity.HasIndex(e => e.NotiId, "fk_users_notifications_noti_id_idx");

            entity.HasIndex(e => e.UserId, "fk_users_notifications_user_id_idx");

            entity.HasIndex(e => new { e.UserId, e.NotiId }, "user_noti_UNIQUE").IsUnique();

            entity.Property(e => e.UsnoId).HasColumnName("usno_id");
            entity.Property(e => e.NotiId).HasColumnName("noti_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Noti).WithMany(p => p.UsersNotifications)
                .HasForeignKey(d => d.NotiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_notifications_noti_id");

            entity.HasOne(d => d.User).WithMany(p => p.UsersNotifications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_notifications_user_id");
        });

        modelBuilder.Entity<UsersWebsite>(entity =>
        {
            entity.HasKey(e => e.UsweId).HasName("PRIMARY");

            entity.ToTable("users_websites");

            entity.HasIndex(e => e.WebsId, "fk_users_websites_website");

            entity.HasIndex(e => new { e.AdministradorId, e.WebsId }, "uswe_user_webs_UNIQUE").IsUnique();

            entity.Property(e => e.UsweId).HasColumnName("uswe_id");
            entity.Property(e => e.AdministradorId).HasColumnName("administrador_id");
            entity.Property(e => e.WebsId).HasColumnName("webs_id");

            entity.HasOne(d => d.Administrador).WithMany(p => p.UsersWebsites)
                .HasForeignKey(d => d.AdministradorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_websites_user");

            entity.HasOne(d => d.Webs).WithMany(p => p.UsersWebsites)
                .HasForeignKey(d => d.WebsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_websites_website");
        });

        modelBuilder.Entity<UsersWorkspace>(entity =>
        {
            entity.HasKey(e => e.UswoId).HasName("PRIMARY");

            entity.ToTable("users_workspaces");

            entity.HasIndex(e => e.AdministradorId, "fk_users_workspaces_administrador_id_idx");

            entity.HasIndex(e => e.ParticipanteId, "fk_users_workspaces_participante_id_idx").IsUnique();

            entity.HasIndex(e => e.WorkId, "fk_users_workspaces_work_id_idx");

            entity.Property(e => e.UswoId).HasColumnName("uswo_id");
            entity.Property(e => e.AdministradorId).HasColumnName("administrador_id");
            entity.Property(e => e.ParticipanteId).HasColumnName("participante_id");
            entity.Property(e => e.WorkId).HasColumnName("work_id");

            entity.HasOne(d => d.Administrador).WithMany(p => p.UsersWorkspaceAdministradors)
                .HasForeignKey(d => d.AdministradorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_workspaces_administrador_id");

            entity.HasOne(d => d.Participante).WithOne(p => p.UsersWorkspaceParticipante)
                .HasForeignKey<UsersWorkspace>(d => d.ParticipanteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_workspaces_participante_id");

            entity.HasOne(d => d.Work).WithMany(p => p.UsersWorkspaces)
                .HasForeignKey(d => d.WorkId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_workspaces_work_id");
        });

        modelBuilder.Entity<Website>(entity =>
        {
            entity.HasKey(e => e.WebsId).HasName("PRIMARY");

            entity.ToTable("websites");

            entity.HasIndex(e => e.WebsUrlHash, "webs_url_hash_UNIQUE").IsUnique();

            entity.Property(e => e.WebsId).HasColumnName("webs_id");
            entity.Property(e => e.WebsCreatedAt)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("webs_created_at");
            entity.Property(e => e.WebsCreatedBy).HasColumnName("webs_created_by");
            entity.Property(e => e.WebsImagePath)
                .HasMaxLength(500)
                .HasColumnName("webs_image_path");
            entity.Property(e => e.WebsStatus)
                .HasDefaultValueSql("'UNBLOCKED'")
                .HasColumnType("enum('BLOCKED','UNBLOCKED')")
                .HasColumnName("webs_status");
            entity.Property(e => e.WebsUrl)
                .HasMaxLength(2048)
                .HasColumnName("webs_url");
            entity.Property(e => e.WebsUrlHash)
                .HasMaxLength(32)
                .IsFixedLength()
                .HasColumnName("webs_url_hash");
        });

        modelBuilder.Entity<Workspace>(entity =>
        {
            entity.HasKey(e => e.WorkId).HasName("PRIMARY");

            entity.ToTable("workspaces");

            entity.HasIndex(e => e.HeadId, "fk_workspaces_head_id_idx");

            entity.Property(e => e.WorkId).HasColumnName("work_id");
            entity.Property(e => e.HeadId).HasColumnName("head_id");
            entity.Property(e => e.WorkCreatedAt)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("work_created_at");
            entity.Property(e => e.WorkCreatedBy).HasColumnName("work_created_by");
            entity.Property(e => e.WorkName)
                .HasMaxLength(35)
                .HasColumnName("work_name");
            entity.Property(e => e.WorkUpdateAt)
                .HasMaxLength(6)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("work_update_at");
            entity.Property(e => e.WorkUpdateBy).HasColumnName("work_update_by");

            entity.HasOne(d => d.Head).WithMany(p => p.Workspaces)
                .HasForeignKey(d => d.HeadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_workspaces_head_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
