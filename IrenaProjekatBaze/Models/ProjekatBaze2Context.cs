using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace IrenaProjekatBaze.Models;

public partial class ProjekatBaze2Context : DbContext
{
    public ProjekatBaze2Context()
    {
    }

    public ProjekatBaze2Context(DbContextOptions<ProjekatBaze2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Autobu> Autobus { get; set; }

    public virtual DbSet<Automobil> Automobils { get; set; }

    public virtual DbSet<Kombi> Kombis { get; set; }

    public virtual DbSet<Korisnik> Korisniks { get; set; }

    public virtual DbSet<Putnik> Putniks { get; set; }

    public virtual DbSet<Rezervacija> Rezervacijas { get; set; }

    public virtual DbSet<Rutum> Ruta { get; set; }

    public virtual DbSet<Termin> Termins { get; set; }

    public virtual DbSet<Uplatum> Uplata { get; set; }

    public virtual DbSet<Vozac> Vozacs { get; set; }

    public virtual DbSet<Vozi> Vozis { get; set; }

    public virtual DbSet<Vozilo> Vozilos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["ProjekatBaza2ConnectionString"].ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autobu>(entity =>
        {
            entity.HasKey(e => e.VoziloId).HasName("AUTOBUS_PK");

            entity.ToTable("AUTOBUS");

            entity.Property(e => e.VoziloId).ValueGeneratedNever();
            entity.Property(e => e.Marka)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Vozilo).WithOne(p => p.Autobu)
                .HasForeignKey<Autobu>(d => d.VoziloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("AUTOBUS_VOZILO_FK");
        });

        modelBuilder.Entity<Automobil>(entity =>
        {
            entity.HasKey(e => e.VoziloId).HasName("AUTOMOBIL_PK");

            entity.ToTable("AUTOMOBIL");

            entity.Property(e => e.VoziloId).ValueGeneratedNever();
            entity.Property(e => e.Pogon)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Vozilo).WithOne(p => p.Automobil)
                .HasForeignKey<Automobil>(d => d.VoziloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("AUTOMOBIL_VOZILO_FK");
        });

        modelBuilder.Entity<Kombi>(entity =>
        {
            entity.HasKey(e => e.VoziloId).HasName("KOMBI_PK");

            entity.ToTable("KOMBI");

            entity.Property(e => e.VoziloId).ValueGeneratedNever();
            entity.Property(e => e.Nosivost)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Vozilo).WithOne(p => p.Kombi)
                .HasForeignKey<Kombi>(d => d.VoziloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("KOMBI_VOZILO_FK");
        });

        modelBuilder.Entity<Korisnik>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("KORISNIK_PK");

            entity.ToTable("KORISNIK");

            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Ime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Jmbg)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Prezime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Putnik>(entity =>
        {
            entity.HasKey(e => e.PutnikId).HasName("PUTNIK_PK");

            entity.ToTable("PUTNIK");

            entity.Property(e => e.PutnikId).ValueGeneratedNever();
            entity.Property(e => e.Ime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Prezime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Vozilo).WithMany(p => p.Putniks)
                .HasForeignKey(d => d.VoziloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PUTNIK_VOZILO_FK");
        });

        modelBuilder.Entity<Rezervacija>(entity =>
        {
            entity.HasKey(e => new { e.RezId, e.PutnikId, e.TerminId }).HasName("REZERVACIJA_PK");

            entity.ToTable("REZERVACIJA");

            entity.HasOne(d => d.Putnik).WithMany(p => p.Rezervacijas)
                .HasForeignKey(d => d.PutnikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("REZERVACIJA_PUTNIK_FK");

            entity.HasOne(d => d.Termin).WithMany(p => p.Rezervacijas)
                .HasForeignKey(d => new { d.TerminId, d.RutaId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("REZERVACIJA_TERMIN_FK");

            entity.HasOne(d => d.Uplatum).WithMany(p => p.Rezervacijas)
                .HasForeignKey(d => new { d.UplataId, d.PutnikId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("REZERVACIJA_UPLATA_FK");
        });

        modelBuilder.Entity<Rutum>(entity =>
        {
            entity.HasKey(e => e.RutaId).HasName("RUTA_PK");

            entity.ToTable("RUTA");

            entity.Property(e => e.RutaId).ValueGeneratedNever();
            entity.Property(e => e.Distanca)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Odrediste)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Polaziste)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Vreme)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Termin>(entity =>
        {
            entity.HasKey(e => new { e.TerminId, e.RutaId }).HasName("TERMIN_PK");

            entity.ToTable("TERMIN");

            entity.Property(e => e.Datum)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Vreme)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Ruta).WithMany(p => p.Termins)
                .HasForeignKey(d => d.RutaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TERMIN_RUTA_FK");

            entity.HasOne(d => d.Vozac).WithMany(p => p.Termins)
                .HasForeignKey(d => d.VozacId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TERMIN_VOZAC_FK");
        });

        modelBuilder.Entity<Uplatum>(entity =>
        {
            entity.HasKey(e => new { e.UplataId, e.PutnikId }).HasName("UPLATA_PK");

            entity.ToTable("UPLATA");

            entity.Property(e => e.Datum)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NacinPl)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Putnik).WithMany(p => p.Uplata)
                .HasForeignKey(d => d.PutnikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UPLATA_PUTNIK_FK");
        });

        modelBuilder.Entity<Vozac>(entity =>
        {
            entity.HasKey(e => e.VozacId).HasName("VOZAC_PK");

            entity.ToTable("VOZAC");

            entity.Property(e => e.VozacId).ValueGeneratedNever();
            entity.Property(e => e.Ime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Prezime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Vozi>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("VOZI");

            entity.HasOne(d => d.Vozac).WithMany()
                .HasForeignKey(d => d.VozacId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("VOZI_VOZAC_FK");

            entity.HasOne(d => d.Vozilo).WithMany()
                .HasForeignKey(d => d.VoziloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("VOZI_VOZILO_FK");
        });

        modelBuilder.Entity<Vozilo>(entity =>
        {
            entity.HasKey(e => e.VoziloId).HasName("VOZILO_PK");

            entity.ToTable("VOZILO");

            entity.Property(e => e.VoziloId).ValueGeneratedNever();
            entity.Property(e => e.Boja)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasMany(d => d.Ruta).WithMany(p => p.Vozilos)
                .UsingEntity<Dictionary<string, object>>(
                    "Sekrece",
                    r => r.HasOne<Rutum>().WithMany()
                        .HasForeignKey("RutaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("SEKRECE_RUTA_FK"),
                    l => l.HasOne<Vozilo>().WithMany()
                        .HasForeignKey("VoziloId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("SEKRECE_VOZILO_FK"),
                    j =>
                    {
                        j.HasKey("VoziloId", "RutaId").HasName("SEKRECE_PK");
                        j.ToTable("SEKRECE");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
