using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DOPRAVY_API.Models;

public partial class DopravyContext : DbContext
{
    public DopravyContext()
    {
    }

    public DopravyContext(DbContextOptions<DopravyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrador> Administradors { get; set; }

    public virtual DbSet<Camion> Camions { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Conductor> Conductors { get; set; }

    public virtual DbSet<Encargo> Encargos { get; set; }

    public virtual DbSet<Sexo> Sexos { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<TipoSeguro> TipoSeguros { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-OQLT3PF\\SQLEXPRESS;Database=DOPRAVY;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>(entity =>
        {
            entity.HasKey(e => e.AdminNickname).HasName("PK__ADMININI__7AA18B9F164452B1");

            entity.ToTable("ADMINISTRADOR");

            entity.Property(e => e.AdminNickname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ADMIN_NICKNAME");
            entity.Property(e => e.AdminPw)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("ADMIN_PW");
        });

        modelBuilder.Entity<Camion>(entity =>
        {
            entity.HasKey(e => e.CamUnidad).HasName("PK__CAMION__81B8AECB30F848ED");

            entity.ToTable("CAMION");

            entity.Property(e => e.CamUnidad)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("CAM_UNIDAD");
            entity.Property(e => e.CamChasis)
                .HasMaxLength(17)
                .IsUnicode(false)
                .HasColumnName("CAM_CHASIS");
            entity.Property(e => e.CamColor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CAM_COLOR");
            entity.Property(e => e.CamMarca)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CAM_MARCA");
            entity.Property(e => e.CamModelo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CAM_MODELO");
            entity.Property(e => e.CamPlaca)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("CAM_PLACA");
            entity.Property(e => e.CamStatus)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("CAM_STATUS");
            entity.Property(e => e.CamTiposeguroid)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CAM_TIPOSEGUROID");
            entity.Property(e => e.CamTipovehiculo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CAM_TIPOVEHICULO");

            entity.HasOne(d => d.CamStatusNavigation).WithMany(p => p.Camions)
                .HasForeignKey(d => d.CamStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CAMION__CAM_STAT__33D4B598");

            entity.HasOne(d => d.CamTiposeguro).WithMany(p => p.Camions)
                .HasForeignKey(d => d.CamTiposeguroid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CAMION__CAM_TIPO__32E0915F");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.CliCedula).HasName("PK__CLIENTES__2E68D5F707020F21");

            entity.ToTable("CLIENTES");

            entity.Property(e => e.CliCedula)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("CLI_CEDULA");
            entity.Property(e => e.CliApellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CLI_APELLIDO");
            entity.Property(e => e.CliFechnac)
                .HasColumnType("date")
                .HasColumnName("CLI_FECHNAC");
            entity.Property(e => e.CliNombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CLI_NOMBRE");
            entity.Property(e => e.CliPw)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("CLI_PW");
            entity.Property(e => e.CliSexo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CLI_SEXO");
            entity.Property(e => e.CliStatus)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("CLI_STATUS");

            entity.HasOne(d => d.CliSexoNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.CliSexo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CLIENTES__CLI_SE__08EA5793");

            entity.HasOne(d => d.CliStatusNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.CliStatus)
                .HasConstraintName("FK__CLIENTES__CLI_ST__09DE7BCC");
        });

        modelBuilder.Entity<Conductor>(entity =>
        {
            entity.HasKey(e => e.ConCedula).HasName("PK__CONDUCTO__50AEAD901B0907CE");

            entity.ToTable("CONDUCTOR");

            entity.Property(e => e.ConCedula)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("CON_CEDULA");
            entity.Property(e => e.CliFechnac)
                .HasColumnType("date")
                .HasColumnName("CLI_FECHNAC");
            entity.Property(e => e.ConApellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CON_APELLIDO");
            entity.Property(e => e.ConDireccion)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("CON_DIRECCION");
            entity.Property(e => e.ConNacionalidad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CON_NACIONALIDAD");
            entity.Property(e => e.ConNiveledu)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CON_NIVELEDU");
            entity.Property(e => e.ConNombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CON_NOMBRE");
            entity.Property(e => e.ConSexo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CON_SEXO");
            entity.Property(e => e.ConStatus)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("CON_STATUS");

            entity.HasOne(d => d.ConSexoNavigation).WithMany(p => p.Conductors)
                .HasForeignKey(d => d.ConSexo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CONDUCTOR__CON_S__1CF15040");

            entity.HasOne(d => d.ConStatusNavigation).WithMany(p => p.Conductors)
                .HasForeignKey(d => d.ConStatus)
                .HasConstraintName("FK__CONDUCTOR__CON_S__1DE57479");
        });

        modelBuilder.Entity<Encargo>(entity =>
        {
            entity.HasKey(e => e.EncId);

            entity.ToTable("ENCARGOS");

            entity.Property(e => e.EncId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(6, 0)")
                .HasColumnName("ENC_ID");
            entity.Property(e => e.EncClicedula)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("ENC_CLICEDULA");
            entity.Property(e => e.EncConductorcedula)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("ENC_CONDUCTORCEDULA");
            entity.Property(e => e.EncDesc)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ENC_DESC");
            entity.Property(e => e.EncLugardescarga)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("ENC_LUGARDESCARGA");
            entity.Property(e => e.EncProvinciaid)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ENC_PROVINCIAID");
            entity.Property(e => e.EncSector)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ENC_SECTOR");
            entity.Property(e => e.EncStatus)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("ENC_STATUS");
            entity.Property(e => e.EncTipoenc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ENC_TIPOENC");
            entity.Property(e => e.EncUnidad)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ENC_UNIDAD");

            entity.HasOne(d => d.EncClicedulaNavigation).WithMany(p => p.Encargos)
                .HasForeignKey(d => d.EncClicedula)
                .HasConstraintName("FK_ENCARGOS_CLIENTES");

            entity.HasOne(d => d.EncConductorcedulaNavigation).WithMany(p => p.Encargos)
                .HasForeignKey(d => d.EncConductorcedula)
                .HasConstraintName("FK_ENCARGOS_CONDUCTOR");

            entity.HasOne(d => d.EncStatusNavigation).WithMany(p => p.Encargos)
                .HasForeignKey(d => d.EncStatus)
                .HasConstraintName("FK_ENCARGOS_STATUS");

            entity.HasOne(d => d.EncUnidadNavigation).WithMany(p => p.Encargos)
                .HasForeignKey(d => d.EncUnidad)
                .HasConstraintName("FK_ENCARGOS_CAMION");
        });

        modelBuilder.Entity<Sexo>(entity =>
        {
            entity.HasKey(e => e.SexoDesc).HasName("PK__SEXO__1465E63F03317E3D");

            entity.ToTable("SEXO");

            entity.Property(e => e.SexoDesc)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SEXO_DESC");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StaDesc).HasName("PK__STATUS__383597387F60ED59");

            entity.ToTable("STATUS");

            entity.Property(e => e.StaDesc)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("STA_DESC");
        });

        modelBuilder.Entity<TipoSeguro>(entity =>
        {
            entity.HasKey(e => e.TsDesc).HasName("PK__TIPO_SEG__8ACC4A5A2D27B809");

            entity.ToTable("TIPO_SEGURO");

            entity.Property(e => e.TsDesc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TS_DESC");
            entity.Property(e => e.TsId).HasColumnName("TS_ID");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.CliCedula);

            entity.ToTable("usuarios");

            entity.Property(e => e.CliCedula)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("cliCedula");
            entity.Property(e => e.CliPw)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("cliPw");

            entity.HasOne(d => d.CliCedulaNavigation).WithOne(p => p.Usuario)
                .HasForeignKey<Usuario>(d => d.CliCedula)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_usuarios_CLIENTES");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
