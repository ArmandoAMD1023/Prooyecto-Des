using System;
using System.Collections.Generic;
using AccesoADatos.Models;
using Microsoft.EntityFrameworkCore;

namespace AccesoADatos.Context;

public partial class ConferenciasContext : DbContext
{
    public ConferenciasContext()
    {
    }

    public ConferenciasContext(DbContextOptions<ConferenciasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asistencium> Asistencia { get; set; }

    public virtual DbSet<Conferencia> Conferencias { get; set; }

    public virtual DbSet<Participante> Participantes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MEJIA\\FABZSQL;Database=Conferencias;Trust Server Certificate=true;User Id=sa;Password=admin;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asistencium>(entity =>
        {
            entity.HasKey(e => e.IdAsistencia).HasName("PK__Asistenc__8A115D6A3F9A40E1");

            entity.Property(e => e.IdAsistencia).HasColumnName("ID_Asistencia");
            entity.Property(e => e.IdConferencia).HasColumnName("ID_Conferencia");
            entity.Property(e => e.IdParticipante).HasColumnName("ID_Participante");

            entity.HasOne(d => d.IdConferenciaNavigation).WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.IdConferencia)
                .HasConstraintName("FK__Asistenci__ID_Co__3C69FB99");

            entity.HasOne(d => d.IdParticipanteNavigation).WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.IdParticipante)
                .HasConstraintName("FK__Asistenci__ID_Pa__3B75D760");
        });

        modelBuilder.Entity<Conferencia>(entity =>
        {
            entity.HasKey(e => e.IdConferencia).HasName("PK__Conferen__D909FC6056379DE0");

            entity.Property(e => e.IdConferencia).HasColumnName("ID_Conferencia");
            entity.Property(e => e.Conferencista)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Horario).HasColumnType("datetime");
            entity.Property(e => e.Registro).IsUnicode(false);
            entity.Property(e => e.TituloConferencia)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Participante>(entity =>
        {
            entity.HasKey(e => e.IdParticipante).HasName("PK__Particip__D4AEE120787779EE");

            entity.Property(e => e.IdParticipante).HasColumnName("ID_Participante");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Avatar).IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ocupacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioTwitter)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
