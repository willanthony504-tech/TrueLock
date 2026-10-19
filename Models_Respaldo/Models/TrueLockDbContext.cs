using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace TrueLock.API.Models;

public partial class TrueLockDbContext : DbContext
{
    public TrueLockDbContext()
    {
    }

    public TrueLockDbContext(DbContextOptions<TrueLockDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Access> Accesses { get; set; }

    public virtual DbSet<ActivityLog> ActivityLogs { get; set; }

    public virtual DbSet<BlockConfig> BlockConfigs { get; set; }

    public virtual DbSet<BlockConfigsBlockRule> BlockConfigsBlockRules { get; set; }

    public virtual DbSet<BlockRule> BlockRules { get; set; }

    public virtual DbSet<BlockRulesUnlockRequest> BlockRulesUnlockRequests { get; set; }

    public virtual DbSet<Computer> Computers { get; set; }

    public virtual DbSet<Headquarter> Headquarters { get; set; }

    public virtual DbSet<Institution> Institutions { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<SupportTicket> SupportTickets { get; set; }

    public virtual DbSet<Tracing> Tracings { get; set; }

    public virtual DbSet<UnlockRequest> UnlockRequests { get; set; }

    public virtual DbSet<UnlockRequestsComputer> UnlockRequestsComputers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersBlockConfig> UsersBlockConfigs { get; set; }

    public virtual DbSet<UsersBlockRule> UsersBlockRules { get; set; }

    public virtual DbSet<UsersComputer> UsersComputers { get; set; }

    public virtual DbSet<UsersNotification> UsersNotifications { get; set; }

    public virtual DbSet<UsersWorkspace> UsersWorkspaces { get; set; }

    public virtual DbSet<VwActivityHistory> VwActivityHistories { get; set; }

    public virtual DbSet<VwParticipantComputer> VwParticipantComputers { get; set; }

    public virtual DbSet<VwUnlockRequest> VwUnlockRequests { get; set; }

    public virtual DbSet<Workspace> Workspaces { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("name=ConnectionStrings:TrueLockDatabase", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.4.11-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_unicode_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Access>(entity =>
        {
            entity.HasKey(e => e.AcceId).HasName("PRIMARY");

            entity.Property(e => e.AcceCreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.AccePasswordChangedAt).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.AcceStatus).HasDefaultValueSql("'ACTIVE'");
            entity.Property(e => e.AcceUpdateAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.HasOne(d => d.Perm).WithMany(p => p.Accesses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_access_perm_id");

            entity.HasOne(d => d.User).WithMany(p => p.Accesses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_accesses_user_id");
        });

        modelBuilder.Entity<ActivityLog>(entity =>
        {
            entity.HasKey(e => e.AcloId).HasName("PRIMARY");

            entity.Property(e => e.AcloCreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.HasOne(d => d.Comp).WithMany(p => p.ActivityLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_activity_logs_comp_id");

            entity.HasOne(d => d.Participante).WithMany(p => p.ActivityLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_activity_logs_participante_id");
        });

        modelBuilder.Entity<BlockConfig>(entity =>
        {
            entity.HasKey(e => e.BlcoId).HasName("PRIMARY");

            entity.Property(e => e.BlcoCreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.BlcoUpdateAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
        });

        modelBuilder.Entity<BlockConfigsBlockRule>(entity =>
        {
            entity.HasKey(e => e.BlblId).HasName("PRIMARY");

            entity.HasOne(d => d.Blco).WithMany(p => p.BlockConfigsBlockRules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_block_configs_block_rules_blco_id");

            entity.HasOne(d => d.Blru).WithMany(p => p.BlockConfigsBlockRules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_block_configs_block_rules_blru_id");
        });

        modelBuilder.Entity<BlockRule>(entity =>
        {
            entity.HasKey(e => e.BlruId).HasName("PRIMARY");

            entity.Property(e => e.BlruCreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.BlruUpdateAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
        });

        modelBuilder.Entity<BlockRulesUnlockRequest>(entity =>
        {
            entity.HasKey(e => e.BlunId).HasName("PRIMARY");

            entity.HasOne(d => d.Blru).WithMany(p => p.BlockRulesUnlockRequests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_block_rules_unlock_requests_blru_id");

            entity.HasOne(d => d.Unre).WithMany(p => p.BlockRulesUnlockRequests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_block_rules_unlock_requests_unre_id");
        });

        modelBuilder.Entity<Computer>(entity =>
        {
            entity.HasKey(e => e.CompId).HasName("PRIMARY");

            entity.Property(e => e.CompCreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.CompUpdateAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.HasOne(d => d.Work).WithMany(p => p.Computers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_computers_work_id");
        });

        modelBuilder.Entity<Headquarter>(entity =>
        {
            entity.HasKey(e => e.HeadId).HasName("PRIMARY");

            entity.Property(e => e.HeadCreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.HeadUpdateAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.HasOne(d => d.Administrador).WithMany(p => p.HeadquarterAdministradors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_headquarters_administrador_id");

            entity.HasOne(d => d.Director).WithMany(p => p.HeadquarterDirectors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_headquarters_director_id");

            entity.HasOne(d => d.Inst).WithMany(p => p.Headquarters)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_headquarters_inst_id");
        });

        modelBuilder.Entity<Institution>(entity =>
        {
            entity.HasKey(e => e.InstId).HasName("PRIMARY");

            entity.Property(e => e.InstCreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.InstUpdateAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.HasOne(d => d.Director).WithMany(p => p.Institutions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_institutions_director_id");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotiId).HasName("PRIMARY");

            entity.Property(e => e.NotiCreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.PermId).HasName("PRIMARY");

            entity.Property(e => e.PermCreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.PermUpdateAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PRIMARY");

            entity.Property(e => e.RoleCreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.RoleUpdateAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(e => e.RopeId).HasName("PRIMARY");

            entity.HasOne(d => d.Perm).WithMany(p => p.RolePermissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_role_permissions_perm_id");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_role_permissions_role_id");
        });

        modelBuilder.Entity<SupportTicket>(entity =>
        {
            entity.HasKey(e => e.SutiId).HasName("PRIMARY");

            entity.Property(e => e.SutiCreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.HasOne(d => d.Noti).WithMany(p => p.SupportTickets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_support_tickets_noti_id");
        });

        modelBuilder.Entity<Tracing>(entity =>
        {
            entity.HasKey(e => e.TracId).HasName("PRIMARY");

            entity.Property(e => e.TracCreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.TracUpdateAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.HasOne(d => d.Participante).WithMany(p => p.Tracings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tracing_participante_id");
        });

        modelBuilder.Entity<UnlockRequest>(entity =>
        {
            entity.HasKey(e => e.UnreId).HasName("PRIMARY");

            entity.Property(e => e.UnreCreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.UnreUpdateAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.HasOne(d => d.Administrador).WithMany(p => p.UnlockRequestAdministradors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_unlock_requests_administrador_id");

            entity.HasOne(d => d.Participante).WithMany(p => p.UnlockRequestParticipantes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_unlock_requests_participante_id");
        });

        modelBuilder.Entity<UnlockRequestsComputer>(entity =>
        {
            entity.HasKey(e => e.UncoId).HasName("PRIMARY");

            entity.HasOne(d => d.Comp).WithMany(p => p.UnlockRequestsComputers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_unlock_requests_computers_comp_id");

            entity.HasOne(d => d.Unre).WithMany(p => p.UnlockRequestsComputers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_unlock_requests_computers_unre_id");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.Property(e => e.UserCreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.UserStatus).HasDefaultValueSql("'ACTIVE'");
            entity.Property(e => e.UserUpdateAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_role_id");
        });

        modelBuilder.Entity<UsersBlockConfig>(entity =>
        {
            entity.HasKey(e => e.UsbcId).HasName("PRIMARY");

            entity.HasOne(d => d.Administrador).WithMany(p => p.UsersBlockConfigs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_block_configs_administrador_id");

            entity.HasOne(d => d.Blco).WithMany(p => p.UsersBlockConfigs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_block_configs_blco_id");
        });

        modelBuilder.Entity<UsersBlockRule>(entity =>
        {
            entity.HasKey(e => e.UsbrId).HasName("PRIMARY");

            entity.HasOne(d => d.Administrador).WithMany(p => p.UsersBlockRules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_block_rules_administrador_id");

            entity.HasOne(d => d.Blru).WithMany(p => p.UsersBlockRules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_block_rules_blru_id");
        });

        modelBuilder.Entity<UsersComputer>(entity =>
        {
            entity.HasKey(e => e.UscoId).HasName("PRIMARY");

            entity.HasOne(d => d.Comp).WithMany(p => p.UsersComputers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_computers_comp_id");

            entity.HasOne(d => d.User).WithMany(p => p.UsersComputers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_computers_user_id");
        });

        modelBuilder.Entity<UsersNotification>(entity =>
        {
            entity.HasKey(e => e.UsnoId).HasName("PRIMARY");

            entity.HasOne(d => d.Noti).WithMany(p => p.UsersNotifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_notifications_noti_id");

            entity.HasOne(d => d.User).WithMany(p => p.UsersNotifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_notifications_user_id");
        });

        modelBuilder.Entity<UsersWorkspace>(entity =>
        {
            entity.HasKey(e => e.UswoId).HasName("PRIMARY");

            entity.HasOne(d => d.Administrador).WithMany(p => p.UsersWorkspaceAdministradors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_workspaces_administrador_id");

            entity.HasOne(d => d.Participante).WithOne(p => p.UsersWorkspaceParticipante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_workspaces_participante_id");

            entity.HasOne(d => d.Work).WithMany(p => p.UsersWorkspaces)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_workspaces_work_id");
        });

        modelBuilder.Entity<VwActivityHistory>(entity =>
        {
            entity.ToView("vw_activity_history");

            entity.Property(e => e.AcloCreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
        });

        modelBuilder.Entity<VwParticipantComputer>(entity =>
        {
            entity.ToView("vw_participant_computers");
        });

        modelBuilder.Entity<VwUnlockRequest>(entity =>
        {
            entity.ToView("vw_unlock_requests");

            entity.Property(e => e.UnreCreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
        });

        modelBuilder.Entity<Workspace>(entity =>
        {
            entity.HasKey(e => e.WorkId).HasName("PRIMARY");

            entity.Property(e => e.WorkCreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.WorkUpdateAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.HasOne(d => d.Head).WithMany(p => p.Workspaces)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_workspaces_head_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
