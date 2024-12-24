using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WinFormsApp1;

public partial class PartnersDbContext : DbContext
{
    public PartnersDbContext()
    {
    }

    public PartnersDbContext(DbContextOptions<PartnersDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PartnersProduction> PartnersProductions { get; set; }

    public virtual DbSet<Production> Productions { get; set; }

    public virtual DbSet<TypesOfPartner> TypesOfPartners { get; set; }

    public virtual DbSet<TypesOfProduction> TypesOfProductions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=PartnersDB;Username=postgres;Password=1111");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Partners_pkey");

            entity.Property(e => e.Email).HasMaxLength(40);
            entity.Property(e => e.FullNameOfDirector).HasMaxLength(100);
            entity.Property(e => e.Inn)
                .HasMaxLength(20)
                .HasColumnName("INN");
            entity.Property(e => e.LegalAdress).HasMaxLength(1000);
            entity.Property(e => e.NameOfPartner).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(20);

            entity.HasOne(d => d.IdTypeOfPartnerNavigation).WithMany(p => p.Partners)
                .HasForeignKey(d => d.IdTypeOfPartner)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdTypeOfPartner");

            entity.HasMany(d => d.PartnersProductions).WithOne(p => p.IdPartnerNavigation)
                .HasForeignKey(p => p.IdPartner)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idPartner");
        });


        modelBuilder.Entity<PartnersProduction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PartnersProductions_pkey");

            entity.Property(e => e.IdPartner).HasColumnName("idPartner");
            entity.Property(e => e.IdProduction).HasColumnName("idProduction");

            entity.HasOne(d => d.IdPartnerNavigation).WithMany(p => p.PartnersProductions)
                .HasForeignKey(d => d.IdPartner)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idPartner");

            entity.HasOne(d => d.IdProductionNavigation).WithMany(p => p.PartnersProductions)
                .HasForeignKey(d => d.IdProduction)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idProduction");
        });

        modelBuilder.Entity<Production>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Production_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("nextval('\"Production_Id_seq\"'::regclass)");
            entity.Property(e => e.Article).HasMaxLength(40);
            entity.Property(e => e.MinPriceForPartner).HasColumnType("money");
            entity.Property(e => e.NameOfProduction).HasMaxLength(100);

            entity.HasOne(d => d.IdTypeOfProductionNavigation).WithMany(p => p.Productions)
                .HasForeignKey(d => d.IdTypeOfProduction)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idTypeOfProduction");
        });

        modelBuilder.Entity<TypesOfPartner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("TypesOfPartner_pkey");

            entity.ToTable("TypesOfPartner");

            entity.Property(e => e.Id).HasDefaultValueSql("nextval('\"TypesOfPartner_Id_seq\"'::regclass)");
            entity.Property(e => e.TypeOfPartner).HasMaxLength(1000);

            entity.HasMany(e => e.Partners)
                .WithOne(e => e.IdTypeOfPartnerNavigation)
                .HasForeignKey(e => e.IdTypeOfPartner)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdTypeOfPartner");
        });

        modelBuilder.Entity<TypesOfProduction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("TypesOfProduction_pkey");

            entity.ToTable("TypesOfProduction");

            entity.Property(e => e.TypeOfProduction).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
