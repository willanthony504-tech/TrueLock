using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TrueLock.API.ModelsVerificados;

public partial class TrueLockDbContext : DbContext
{
    public TrueLockDbContext(DbContextOptions<TrueLockDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<access> accesses { get; set; }

    public virtual DbSet<activity_log> activity_logs { get; set; }

    public virtual DbSet<application> applications { get; set; }

    public virtual DbSet<block_config> block_configs { get; set; }

    public virtual DbSet<block_configs_block_rule> block_configs_block_rules { get; set; }

    public virtual DbSet<block_rule> block_rules { get; set; }

    public virtual DbSet<block_rules_unlock_request> block_rules_unlock_requests { get; set; }

    public virtual DbSet<computer> computers { get; set; }

    public virtual DbSet<headquarter> headquarters { get; set; }

    public virtual DbSet<notification> notifications { get; set; }

    public virtual DbSet<payment> payments { get; set; }

    public virtual DbSet<permission> permissions { get; set; }

    public virtual DbSet<plan> plans { get; set; }

    public virtual DbSet<role> roles { get; set; }

    public virtual DbSet<role_permission> role_permissions { get; set; }

    public virtual DbSet<schedule> schedules { get; set; }

    public virtual DbSet<subscription> subscriptions { get; set; }

    public virtual DbSet<support_ticket> support_tickets { get; set; }

    public virtual DbSet<tracing> tracings { get; set; }

    public virtual DbSet<unlock_request> unlock_requests { get; set; }

    public virtual DbSet<unlock_requests_computer> unlock_requests_computers { get; set; }

    public virtual DbSet<user> users { get; set; }

    public virtual DbSet<users_application> users_applications { get; set; }

    public virtual DbSet<users_block_config> users_block_configs { get; set; }

    public virtual DbSet<users_block_rule> users_block_rules { get; set; }

    public virtual DbSet<users_computer> users_computers { get; set; }

    public virtual DbSet<users_notification> users_notifications { get; set; }

    public virtual DbSet<users_website> users_websites { get; set; }

    public virtual DbSet<users_workspace> users_workspaces { get; set; }

    public virtual DbSet<vw_activity_history> vw_activity_histories { get; set; }

    public virtual DbSet<vw_participant_computer> vw_participant_computers { get; set; }

    public virtual DbSet<vw_unlock_request> vw_unlock_requests { get; set; }

    public virtual DbSet<website> websites { get; set; }

    public virtual DbSet<workspace> workspaces { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_unicode_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<access>(entity =>
        {
            entity.HasKey(e => e.acce_id).HasName("PRIMARY");

            entity.HasIndex(e => e.perm_id, "fk_access_perm_id_idx");

            entity.HasIndex(e => e.user_id, "fk_accesses_user_id_idx");

            entity.Property(e => e.acce_created_at)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.acce_description).HasColumnType("text");
            entity.Property(e => e.acce_last_login_at).HasMaxLength(6);
            entity.Property(e => e.acce_locked_until).HasMaxLength(6);
            entity.Property(e => e.acce_update_at)
                .HasMaxLength(6)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.HasOne(d => d.perm).WithMany(p => p.accesses)
                .HasForeignKey(d => d.perm_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_access_perm_id");

            entity.HasOne(d => d.user).WithMany(p => p.accesses)
                .HasForeignKey(d => d.user_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_accesses_user_id");
        });

        modelBuilder.Entity<activity_log>(entity =>
        {
            entity.HasKey(e => e.aclo_id).HasName("PRIMARY");

            entity.HasIndex(e => e.comp_id, "fk_activity_logs_comp_id_idx");

            entity.HasIndex(e => e.participante_id, "fk_activity_logs_participante_id_idx");

            entity.Property(e => e.aclo_action).HasColumnType("enum('BLOCKED','ALLOWED')");
            entity.Property(e => e.aclo_created_at)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.aclo_description).HasColumnType("text");
            entity.Property(e => e.aclo_resource).HasColumnType("text");
            entity.Property(e => e.aclo_type).HasColumnType("enum('SOFTWARE','WEB')");

            entity.HasOne(d => d.comp).WithMany(p => p.activity_logs)
                .HasForeignKey(d => d.comp_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_activity_logs_comp_id");

            entity.HasOne(d => d.participante).WithMany(p => p.activity_logs)
                .HasForeignKey(d => d.participante_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_activity_logs_participante_id");
        });

        modelBuilder.Entity<application>(entity =>
        {
            entity.HasKey(e => e.appl_id).HasName("PRIMARY");

            entity.HasIndex(e => e.appl_name, "appl_name_UNIQUE").IsUnique();

            entity.Property(e => e.appl_created_at)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.appl_executable_path).HasMaxLength(700);
            entity.Property(e => e.appl_image_path).HasMaxLength(500);
            entity.Property(e => e.appl_name).HasMaxLength(50);
            entity.Property(e => e.appl_status)
                .HasDefaultValueSql("'UNBLOCKED'")
                .HasColumnType("enum('BLOCKED','UNBLOCKED')");
            entity.Property(e => e.appl_update_at)
                .HasMaxLength(6)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
        });

        modelBuilder.Entity<block_config>(entity =>
        {
            entity.HasKey(e => e.blco_id).HasName("PRIMARY");

            entity.Property(e => e.blco_created_at)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.blco_description).HasColumnType("text");
            entity.Property(e => e.blco_name).HasMaxLength(35);
            entity.Property(e => e.blco_update_at)
                .HasMaxLength(6)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
        });

        modelBuilder.Entity<block_configs_block_rule>(entity =>
        {
            entity.HasKey(e => e.blbl_id).HasName("PRIMARY");

            entity.HasIndex(e => new { e.blco_id, e.blru_id }, "blco_blru_UNIQUE").IsUnique();

            entity.HasIndex(e => e.blco_id, "fk_block_configs_block_rules_blco_id_idx");

            entity.HasIndex(e => e.blru_id, "fk_block_configs_block_rules_blru_id_id_idx");

            entity.HasOne(d => d.blco).WithMany(p => p.block_configs_block_rules)
                .HasForeignKey(d => d.blco_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_block_configs_block_rules_blco_id");

            entity.HasOne(d => d.blru).WithMany(p => p.block_configs_block_rules)
                .HasForeignKey(d => d.blru_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_block_configs_block_rules_blru_id");
        });

        modelBuilder.Entity<block_rule>(entity =>
        {
            entity.HasKey(e => e.blru_id).HasName("PRIMARY");

            entity.HasIndex(e => e.blru_name, "blru_name_UNIQUE").IsUnique();

            entity.Property(e => e.blru_created_at)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.blru_description).HasColumnType("text");
            entity.Property(e => e.blru_name).HasMaxLength(40);
            entity.Property(e => e.blru_patron).HasColumnType("enum('BLOCKED','ALLOWED')");
            entity.Property(e => e.blru_type).HasColumnType("enum('SOFTWARE','WEB')");
            entity.Property(e => e.blru_update_at)
                .HasMaxLength(6)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
        });

        modelBuilder.Entity<block_rules_unlock_request>(entity =>
        {
            entity.HasKey(e => e.blun_id).HasName("PRIMARY");

            entity.HasIndex(e => e.blru_id, "fk_block_rules_unlock_requests_blru_id_idx");

            entity.HasIndex(e => e.unre_id, "fk_block_rules_unlock_requests_unre_id_id_idx");

            entity.HasOne(d => d.blru).WithMany(p => p.block_rules_unlock_requests)
                .HasForeignKey(d => d.blru_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_block_rules_unlock_requests_blru_id");

            entity.HasOne(d => d.unre).WithMany(p => p.block_rules_unlock_requests)
                .HasForeignKey(d => d.unre_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_block_rules_unlock_requests_unre_id");
        });

        modelBuilder.Entity<computer>(entity =>
        {
            entity.HasKey(e => e.comp_id).HasName("PRIMARY");

            entity.HasIndex(e => e.work_id, "fk_computers_work_id_idx");

            entity.Property(e => e.comp_created_at)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.comp_name).HasMaxLength(50);
            entity.Property(e => e.comp_status).HasColumnType("enum('ACTIVE','INACTIVE')");
            entity.Property(e => e.comp_update_at)
                .HasMaxLength(6)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.HasOne(d => d.work).WithMany(p => p.computers)
                .HasForeignKey(d => d.work_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_computers_work_id");
        });

        modelBuilder.Entity<headquarter>(entity =>
        {
            entity.HasKey(e => e.head_id).HasName("PRIMARY");

            entity.HasIndex(e => e.administrador_id, "fk_headquarters_administrador_id_idx");

            entity.HasIndex(e => e.director_id, "fk_headquarters_director_id_idx");

            entity.HasIndex(e => e.head_email, "head_email_UNIQUE").IsUnique();

            entity.Property(e => e.head_address).HasMaxLength(60);
            entity.Property(e => e.head_created_at)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.head_email).HasMaxLength(100);
            entity.Property(e => e.head_institutions_belong).HasMaxLength(250);
            entity.Property(e => e.head_name).HasMaxLength(50);
            entity.Property(e => e.head_update_at)
                .HasMaxLength(6)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.HasOne(d => d.administrador).WithMany(p => p.headquarteradministradors)
                .HasForeignKey(d => d.administrador_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_headquarters_administrador_id");

            entity.HasOne(d => d.director).WithMany(p => p.headquarterdirectors)
                .HasForeignKey(d => d.director_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_headquarters_director_id");
        });

        modelBuilder.Entity<notification>(entity =>
        {
            entity.HasKey(e => e.noti_id).HasName("PRIMARY");

            entity.Property(e => e.noti_created_at)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.noti_message).HasColumnType("text");
            entity.Property(e => e.noti_status).HasColumnType("enum('PENDING','REVISED')");
            entity.Property(e => e.noti_title).HasMaxLength(35);
            entity.Property(e => e.noti_type).HasColumnType("enum('REQUEST','WARNING','SUPPORT')");
        });

        modelBuilder.Entity<payment>(entity =>
        {
            entity.HasKey(e => e.paym_id).HasName("PRIMARY");

            entity.HasIndex(e => e.subs_id, "fk_payments_subs_id_idx");

            entity.Property(e => e.paym_id).ValueGeneratedNever();
            entity.Property(e => e.paym_amount).HasPrecision(10, 2);
            entity.Property(e => e.paym_created_at)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.paym_currency)
                .HasMaxLength(3)
                .HasDefaultValueSql("'DLS'")
                .IsFixedLength();
            entity.Property(e => e.paym_description).HasColumnType("text");
            entity.Property(e => e.paym_paid_at).HasMaxLength(6);
            entity.Property(e => e.paym_payment_method).HasColumnType("enum('CARD','BANK_TRANSFER','OTHER')");
            entity.Property(e => e.paym_reference).HasMaxLength(100);
            entity.Property(e => e.paym_status)
                .HasDefaultValueSql("'PENDING'")
                .HasColumnType("enum('PENDING','APPROVED','REJECTED','REFUNDED')");

            entity.HasOne(d => d.subs).WithMany(p => p.payments)
                .HasForeignKey(d => d.subs_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_payments_subs_id");
        });

        modelBuilder.Entity<permission>(entity =>
        {
            entity.HasKey(e => e.perm_id).HasName("PRIMARY");

            entity.HasIndex(e => e.perm_code, "perm_code_UNIQUE").IsUnique();

            entity.HasIndex(e => e.perm_name, "perm_name_UNIQUE").IsUnique();

            entity.Property(e => e.perm_code).HasMaxLength(30);
            entity.Property(e => e.perm_created_at)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.perm_description).HasColumnType("text");
            entity.Property(e => e.perm_name).HasMaxLength(30);
            entity.Property(e => e.perm_update_at)
                .HasMaxLength(6)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
        });

        modelBuilder.Entity<plan>(entity =>
        {
            entity.HasKey(e => e.plan_id).HasName("PRIMARY");

            entity.HasIndex(e => e.plan_name, "plan_name_UNIQUE").IsUnique();

            entity.Property(e => e.plan_created_at)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.plan_description).HasColumnType("text");
            entity.Property(e => e.plan_name).HasMaxLength(45);
            entity.Property(e => e.plan_price).HasPrecision(10, 2);
            entity.Property(e => e.plan_status)
                .HasDefaultValueSql("'ACTIVE'")
                .HasColumnType("enum('ACTIVE','INACTIVE')");
            entity.Property(e => e.plan_update_at)
                .HasMaxLength(6)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("plan_update at");
        });

        modelBuilder.Entity<role>(entity =>
        {
            entity.HasKey(e => e.role_id).HasName("PRIMARY");

            entity.HasIndex(e => e.role_code, "role_code_UNIQUE").IsUnique();

            entity.HasIndex(e => e.role_name, "role_name_UNIQUE").IsUnique();

            entity.Property(e => e.role_code).HasMaxLength(30);
            entity.Property(e => e.role_created_at)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.role_description).HasColumnType("text");
            entity.Property(e => e.role_name).HasColumnType("enum('DIRECTOR','ADMINISTRADOR','PARTICIPANTE')");
            entity.Property(e => e.role_update_at)
                .HasMaxLength(6)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
        });

        modelBuilder.Entity<role_permission>(entity =>
        {
            entity.HasKey(e => e.rope_id).HasName("PRIMARY");

            entity.HasIndex(e => e.perm_id, "fk_role_permissions_perm_id_idx");

            entity.HasIndex(e => e.role_id, "fk_role_permissions_role_id_idx");

            entity.HasIndex(e => new { e.role_id, e.perm_id }, "role_perm_UNIQUE").IsUnique();

            entity.HasOne(d => d.perm).WithMany(p => p.role_permissions)
                .HasForeignKey(d => d.perm_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_role_permissions_perm_id");

            entity.HasOne(d => d.role).WithMany(p => p.role_permissions)
                .HasForeignKey(d => d.role_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_role_permissions_role_id");
        });

        modelBuilder.Entity<schedule>(entity =>
        {
            entity.HasKey(e => e.sche_id).HasName("PRIMARY");

            entity.Property(e => e.sche_end_time).HasColumnType("time");
            entity.Property(e => e.sche_start_time).HasColumnType("time");
            entity.Property(e => e.sche_days)
                .HasColumnType("set('MONDAY','TUESDAY','WEDNESDAY','THURSDAY','FRIDAY','SATURDAY','SUNDAY')");
            entity.Property(e => e.sche_status)
                .HasDefaultValueSql("'INACTIVE'")
                .HasColumnType("enum('ACTIVE','INACTIVE')");
        });

        modelBuilder.Entity<subscription>(entity =>
        {
            entity.HasKey(e => e.subs_id).HasName("PRIMARY");

            entity.HasIndex(e => e.plan_id, "fk_subscriptions_plan_id_idx");

            entity.HasIndex(e => e.director_id, "fk_subscriptions_users1_idx");

            entity.Property(e => e.subs_created_at)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.subs_end_date).HasMaxLength(6);
            entity.Property(e => e.subs_start_date).HasMaxLength(6);
            entity.Property(e => e.subs_status)
                .HasDefaultValueSql("'ACTIVE'")
                .HasColumnType("enum('ACTIVE','EXPIRED','CANCELLED')");

            entity.HasOne(d => d.director).WithMany(p => p.subscriptions)
                .HasForeignKey(d => d.director_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_subscriptions_director_id");

            entity.HasOne(d => d.plan).WithMany(p => p.subscriptions)
                .HasForeignKey(d => d.plan_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_subscriptions_plan_id");
        });

        modelBuilder.Entity<support_ticket>(entity =>
        {
            entity.HasKey(e => e.suti_id).HasName("PRIMARY");

            entity.HasIndex(e => e.noti_id, "fk_support_tickets_noti_id_idx");

            entity.Property(e => e.suti_created_at)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.suti_priority).HasColumnType("enum('LOW','MEDIUM','HIGH')");
            entity.Property(e => e.suti_response_date)
                .HasMaxLength(6)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.suti_status).HasColumnType("enum('OPEN','IN_PROGRESS','RESOLVED')");

            entity.HasOne(d => d.noti).WithMany(p => p.support_tickets)
                .HasForeignKey(d => d.noti_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_support_tickets_noti_id");
        });

        modelBuilder.Entity<tracing>(entity =>
        {
            entity.HasKey(e => e.trac_id).HasName("PRIMARY");

            entity.ToTable("tracing");

            entity.HasIndex(e => e.participante_id, "fk_tracing_participante_id_idx");

            entity.Property(e => e.trac_created_at)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.trac_name).HasColumnType("enum('ACTIVITY_LOGS','SUPPORT','UNLOCK_REQUEST')");
            entity.Property(e => e.trac_update_at)
                .HasMaxLength(6)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.HasOne(d => d.participante).WithMany(p => p.tracings)
                .HasForeignKey(d => d.participante_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tracing_participante_id");
        });

        modelBuilder.Entity<unlock_request>(entity =>
        {
            entity.HasKey(e => e.unre_id).HasName("PRIMARY");

            entity.HasIndex(e => e.administrador_id, "fk_unlock_requests_administrador_id_idx");

            entity.HasIndex(e => e.participante_id, "fk_unlock_requests_participante_id_idx");

            entity.Property(e => e.unre_created_at)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.unre_reason).HasColumnType("text");
            entity.Property(e => e.unre_response_date)
                .HasMaxLength(6)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.unre_status).HasColumnType("enum('PENDING','APPROVED','REJECTED')");
            entity.Property(e => e.unre_update_at)
                .HasMaxLength(6)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.HasOne(d => d.administrador).WithMany(p => p.unlock_requestadministradors)
                .HasForeignKey(d => d.administrador_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_unlock_requests_administrador_id");

            entity.HasOne(d => d.participante).WithMany(p => p.unlock_requestparticipantes)
                .HasForeignKey(d => d.participante_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_unlock_requests_participante_id");
        });

        modelBuilder.Entity<unlock_requests_computer>(entity =>
        {
            entity.HasKey(e => e.unco_id).HasName("PRIMARY");

            entity.HasIndex(e => e.comp_id, "fk_unlock_requests_computers_comp_id_idx");

            entity.HasIndex(e => e.unre_id, "fk_unlock_requests_computers_unre_id_idx");

            entity.HasIndex(e => new { e.comp_id, e.unre_id }, "unco_comp_unre_UNIQUE").IsUnique();

            entity.HasOne(d => d.comp).WithMany(p => p.unlock_requests_computers)
                .HasForeignKey(d => d.comp_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_unlock_requests_computers_comp_id");

            entity.HasOne(d => d.unre).WithMany(p => p.unlock_requests_computers)
                .HasForeignKey(d => d.unre_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_unlock_requests_computers_unre_id");
        });

        modelBuilder.Entity<user>(entity =>
        {
            entity.HasKey(e => e.user_id).HasName("PRIMARY");

            entity.HasIndex(e => e.role_id, "fk_users_role_id_idx");

            entity.HasIndex(e => e.user_document_number, "user_document_number_UNIQUE").IsUnique();

            entity.HasIndex(e => e.user_email, "user_email_UNIQUE").IsUnique();

            entity.HasIndex(e => e.user_phone_number, "user_phone_number_UNIQUE").IsUnique();

            entity.HasIndex(e => e.user_username, "user_username_UNIQUE").IsUnique();

            entity.Property(e => e.user_country_code)
                .HasMaxLength(6)
                .HasDefaultValueSql("'+57'");
            entity.Property(e => e.user_created_at)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.user_document_number).HasMaxLength(40);
            entity.Property(e => e.user_document_type).HasColumnType("enum('P.P','C.C','P.P.T','T.I','OTHER')");
            entity.Property(e => e.user_email).HasMaxLength(100);
            entity.Property(e => e.user_gender).HasColumnType("enum('MAN','WOMAN','OTHER','PREFER_NOT_TO_SAY')");
            entity.Property(e => e.user_last_names).HasMaxLength(100);
            entity.Property(e => e.user_names).HasMaxLength(100);
            entity.Property(e => e.user_password_changed_at)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.user_password_hash).HasMaxLength(255);
            entity.Property(e => e.user_phone_number).HasMaxLength(20);
            entity.Property(e => e.user_profile_photo).HasMaxLength(450);
            entity.Property(e => e.user_sex).HasColumnType("enum('MALE','FEMALE','OTHER','PREFER_NOT_TO_SAY')");
            entity.Property(e => e.user_status)
                .HasDefaultValueSql("'ACTIVE'")
                .HasColumnType("enum('ACTIVE','INACTIVE')");
            entity.Property(e => e.user_update_at)
                .HasMaxLength(6)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.user_username).HasMaxLength(40);

            entity.HasOne(d => d.role).WithMany(p => p.users)
                .HasForeignKey(d => d.role_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_role_id");
        });

        modelBuilder.Entity<users_application>(entity =>
        {
            entity.HasKey(e => e.usap_id).HasName("PRIMARY");

            entity.HasIndex(e => e.appl_id, "fk_users_applications_application");

            entity.HasIndex(e => new { e.administrador_id, e.appl_id }, "usap_user_appl_UNIQUE").IsUnique();

            entity.HasOne(d => d.administrador).WithMany(p => p.users_applications)
                .HasForeignKey(d => d.administrador_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_applications_user");

            entity.HasOne(d => d.appl).WithMany(p => p.users_applications)
                .HasForeignKey(d => d.appl_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_applications_application");
        });

        modelBuilder.Entity<users_block_config>(entity =>
        {
            entity.HasKey(e => e.usbc_id).HasName("PRIMARY");

            entity.HasIndex(e => e.administrador_id, "fk_users_block_configs_administrador_id_idx");

            entity.HasIndex(e => e.blco_id, "fk_users_block_configs_blco_id_idx");

            entity.HasOne(d => d.administrador).WithMany(p => p.users_block_configs)
                .HasForeignKey(d => d.administrador_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_block_configs_administrador_id");

            entity.HasOne(d => d.blco).WithMany(p => p.users_block_configs)
                .HasForeignKey(d => d.blco_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_block_configs_blco_id");
        });

        modelBuilder.Entity<users_block_rule>(entity =>
        {
            entity.HasKey(e => e.usbr_id).HasName("PRIMARY");

            entity.HasIndex(e => e.administrador_id, "fk_users_block_rules_administrador_id_idx");

            entity.HasIndex(e => e.blru_id, "fk_users_block_rules_blru_id_idx");

            entity.HasOne(d => d.administrador).WithMany(p => p.users_block_rules)
                .HasForeignKey(d => d.administrador_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_block_rules_administrador_id");

            entity.HasOne(d => d.blru).WithMany(p => p.users_block_rules)
                .HasForeignKey(d => d.blru_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_block_rules_blru_id");
        });

        modelBuilder.Entity<users_computer>(entity =>
        {
            entity.HasKey(e => e.usco_id).HasName("PRIMARY");

            entity.HasIndex(e => e.comp_id, "fk_users_computers_comp_id_idx");

            entity.HasIndex(e => e.user_id, "fk_users_computers_user_id_idx");

            entity.HasIndex(e => new { e.comp_id, e.user_id }, "usco_comp_user_UNIQUE").IsUnique();

            entity.HasOne(d => d.comp).WithMany(p => p.users_computers)
                .HasForeignKey(d => d.comp_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_computers_comp_id");

            entity.HasOne(d => d.user).WithMany(p => p.users_computers)
                .HasForeignKey(d => d.user_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_computers_user_id");
        });

        modelBuilder.Entity<users_notification>(entity =>
        {
            entity.HasKey(e => e.usno_id).HasName("PRIMARY");

            entity.HasIndex(e => e.noti_id, "fk_users_notifications_noti_id_idx");

            entity.HasIndex(e => e.user_id, "fk_users_notifications_user_id_idx");

            entity.HasIndex(e => new { e.user_id, e.noti_id }, "user_noti_UNIQUE").IsUnique();

            entity.HasOne(d => d.noti).WithMany(p => p.users_notifications)
                .HasForeignKey(d => d.noti_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_notifications_noti_id");

            entity.HasOne(d => d.user).WithMany(p => p.users_notifications)
                .HasForeignKey(d => d.user_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_notifications_user_id");
        });

        modelBuilder.Entity<users_website>(entity =>
        {
            entity.HasKey(e => e.uswe_id).HasName("PRIMARY");

            entity.HasIndex(e => e.webs_id, "fk_users_websites_website");

            entity.HasIndex(e => new { e.administrador_id, e.webs_id }, "uswe_user_webs_UNIQUE").IsUnique();

            entity.HasOne(d => d.administrador).WithMany(p => p.users_websites)
                .HasForeignKey(d => d.administrador_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_websites_user");

            entity.HasOne(d => d.webs).WithMany(p => p.users_websites)
                .HasForeignKey(d => d.webs_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_websites_website");
        });

        modelBuilder.Entity<users_workspace>(entity =>
        {
            entity.HasKey(e => e.uswo_id).HasName("PRIMARY");

            entity.HasIndex(e => e.administrador_id, "fk_users_workspaces_administrador_id_idx");

            entity.HasIndex(e => e.participante_id, "fk_users_workspaces_participante_id_idx").IsUnique();

            entity.HasIndex(e => e.work_id, "fk_users_workspaces_work_id_idx");

            entity.HasOne(d => d.administrador).WithMany(p => p.users_workspaceadministradors)
                .HasForeignKey(d => d.administrador_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_workspaces_administrador_id");

            entity.HasOne(d => d.participante).WithOne(p => p.users_workspaceparticipante)
                .HasForeignKey<users_workspace>(d => d.participante_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_workspaces_participante_id");

            entity.HasOne(d => d.work).WithMany(p => p.users_workspaces)
                .HasForeignKey(d => d.work_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_workspaces_work_id");
        });

        modelBuilder.Entity<vw_activity_history>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_activity_history");

            entity.Property(e => e.aclo_action).HasColumnType("enum('BLOCKED','ALLOWED')");
            entity.Property(e => e.aclo_created_at)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.aclo_description).HasColumnType("text");
            entity.Property(e => e.aclo_resource).HasColumnType("text");
            entity.Property(e => e.aclo_type).HasColumnType("enum('SOFTWARE','WEB')");
            entity.Property(e => e.comp_name).HasMaxLength(50);
            entity.Property(e => e.user_last_names).HasMaxLength(100);
            entity.Property(e => e.user_names).HasMaxLength(100);
        });

        modelBuilder.Entity<vw_participant_computer>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_participant_computers");

            entity.Property(e => e.comp_name).HasMaxLength(50);
            entity.Property(e => e.comp_status).HasColumnType("enum('ACTIVE','INACTIVE')");
            entity.Property(e => e.user_last_names).HasMaxLength(100);
            entity.Property(e => e.user_names).HasMaxLength(100);
            entity.Property(e => e.work_name).HasMaxLength(35);
        });

        modelBuilder.Entity<vw_unlock_request>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_unlock_requests");

            entity.Property(e => e.administrador_last_names).HasMaxLength(100);
            entity.Property(e => e.administrador_names).HasMaxLength(100);
            entity.Property(e => e.unre_created_at)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.unre_reason).HasColumnType("text");
            entity.Property(e => e.unre_response_date)
                .HasMaxLength(6)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.unre_status).HasColumnType("enum('PENDING','APPROVED','REJECTED')");
            entity.Property(e => e.user_last_names).HasMaxLength(100);
            entity.Property(e => e.user_names).HasMaxLength(100);
        });

        modelBuilder.Entity<website>(entity =>
        {
            entity.HasKey(e => e.webs_id).HasName("PRIMARY");

            entity.HasIndex(e => e.webs_url_hash, "webs_url_hash_UNIQUE").IsUnique();

            entity.Property(e => e.webs_created_at)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.webs_image_path).HasMaxLength(500);
            entity.Property(e => e.webs_status)
                .HasDefaultValueSql("'UNBLOCKED'")
                .HasColumnType("enum('BLOCKED','UNBLOCKED')");
            entity.Property(e => e.webs_url).HasMaxLength(2048);
            entity.Property(e => e.webs_url_hash)
                .HasMaxLength(32)
                .IsFixedLength();
        });

        modelBuilder.Entity<workspace>(entity =>
        {
            entity.HasKey(e => e.work_id).HasName("PRIMARY");

            entity.HasIndex(e => e.head_id, "fk_workspaces_head_id_idx");

            entity.Property(e => e.work_created_at)
                .HasMaxLength(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.work_name).HasMaxLength(35);
            entity.Property(e => e.work_update_at)
                .HasMaxLength(6)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            entity.HasOne(d => d.head).WithMany(p => p.workspaces)
                .HasForeignKey(d => d.head_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_workspaces_head_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
