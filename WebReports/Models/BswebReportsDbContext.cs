using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebReports.Models;

public partial class BSWebReportsDbContext : DbContext
{
    public BSWebReportsDbContext()
    {
    }

    public BSWebReportsDbContext(DbContextOptions<BSWebReportsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientMenu> ClientMenus { get; set; }

    public virtual DbSet<ClientUser> ClientUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BSWebReports;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasIndex(e => e.CreatedBy, "IX_Clients_CreatedBy");

            entity.HasIndex(e => e.LastUpdatedBy, "IX_Clients_LastUpdatedBy");

            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.DisabledOn).HasColumnType("datetime");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ClientCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clients_AspNetUsers_CB");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.ClientLastUpdatedByNavigations)
                .HasForeignKey(d => d.LastUpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clients_AspNetUsers_LUB");
        });

        modelBuilder.Entity<ClientMenu>(entity =>
        {
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DisabledOn).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedBy).HasMaxLength(450);
            entity.Property(e => e.MenuUrl)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ReportId)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.ReportName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.WorkspaceId)
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.HasOne(d => d.Client).WithMany(p => p.ClientMenus)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClientMenus_Clients");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ClientMenuCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClientMenus_AspNetUsers");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.ClientMenuLastUpdatedByNavigations)
                .HasForeignKey(d => d.LastUpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClientMenus_AspNetUsers1");
        });

        modelBuilder.Entity<ClientUser>(entity =>
        {
            entity.HasIndex(e => e.ClientId, "IX_ClientUsers_ClientId");

            entity.HasIndex(e => e.CreatedBy, "IX_ClientUsers_CreatedBy");

            entity.HasIndex(e => e.LastUpdatedBy, "IX_ClientUsers_LastUpdatedBy");

            entity.HasIndex(e => e.UserId, "IX_ClientUsers_UserId");

            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DisabledOn).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Client).WithMany(p => p.ClientUsers)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClientUsers_Clients");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ClientUserCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClientUsers_AspNetUsers_CB");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.ClientUserLastUpdatedByNavigations)
                .HasForeignKey(d => d.LastUpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClientUsers_AspNetUsers_LUB");

            entity.HasOne(d => d.User).WithMany(p => p.ClientUserUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClientUsers_AspNetUsers_UI");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
