﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace main.DataLoad;

public partial class ets_dadosContext : DbContext
{
    public ets_dadosContext()
    {
    }

    public ets_dadosContext(DbContextOptions<ets_dadosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DiagnosticosClasseMe> DiagnosticosClasseMes { get; set; } = null!;
    public virtual DbSet<DiagnosticosPorClasse> DiagnosticosPorClasses { get; set; } = null!;
    public virtual DbSet<DoençaIdadeRegiao> DoençaIdadeRegiaos { get; set; } = null!;
    public virtual DbSet<IncidenciasPorIdade> IncidenciasPorIdades { get; set; } = null!;
    public virtual DbSet<NewTable> NewTables { get; set; } = null!;
    public virtual DbSet<OcorrenciasClasseSocialRegiao> OcorrenciasClasseSocialRegiaos { get; set; } = null!;
    public virtual DbSet<PacientesClasseEstado> PacientesClasseEstados { get; set; } = null!;
    public virtual DbSet<ReiciendenciaMesesRegium> ReiciendenciaMesesRegia { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=JVLPC0524\\SQLEXPRESS;Database=ets_dados;Trusted_Connection=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DiagnosticosClasseMe>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("diagnosticos_classe_mes");

            entity.Property(e => e.ClasseSocial)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("classe_social")
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            entity.Property(e => e.Mes).HasColumnName("mes");

            entity.Property(e => e.QuantidadeDiagnosticos).HasColumnName("quantidade_diagnosticos");
        });

        modelBuilder.Entity<DiagnosticosPorClasse>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("diagnosticos_por_classe");

            entity.Property(e => e.ClasseSocial).HasColumnName("classe_social");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            entity.Property(e => e.QuantidadeDiagnosticos).HasColumnName("quantidade_diagnosticos");
        });

        modelBuilder.Entity<DoençaIdadeRegiao>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("doença_idade_regiao");

            entity.Property(e => e.Doenca)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("doenca")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            entity.Property(e => e.MediaIdade).HasColumnName("media_idade");

            entity.Property(e => e.Regiao)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("regiao")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<IncidenciasPorIdade>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("incidencias_por_idade");

            entity.Property(e => e.Estados)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("estados")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            entity.Property(e => e.Idade).HasColumnName("idade");

            entity.Property(e => e.NomeDoenca)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome_doenca")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.Property(e => e.QuantidadeOcorrencias).HasColumnName("quantidade_ocorrencias");
        });

        modelBuilder.Entity<NewTable>(entity =>
        {
            entity.HasKey(p => p.Id).HasName("id");

            entity.ToTable("NewTable");

            entity.Property(e => e.Doenca)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("doenca")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            //entity.Property(e => e.Id)
            //    .ValueGeneratedOnAdd()
            //    .HasColumnName("id");

            entity.Property(e => e.MediaIdade).HasColumnName("media_idade");

            entity.Property(e => e.MediaSalarial).HasColumnName("media_salarial");
        });

        modelBuilder.Entity<OcorrenciasClasseSocialRegiao>(entity =>
        {
            entity.HasKey(p => p.Id).HasName("id");

            entity.ToTable("ocorrencias_classe_social_regiao");

            entity.Property(e => e.ClasseSocial)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("classe_social")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            //entity.Property(e => e.Id)
            //    .ValueGeneratedOnAdd()
            //    .HasColumnName("id");

            entity.Property(e => e.NomeDoença)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome_doença")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.Property(e => e.QuantidadeOcorrencias).HasColumnName("quantidade_ocorrencias");

            entity.Property(e => e.Regiao)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("regiao")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<PacientesClasseEstado>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("pacientes_classe_estado");

            entity.Property(e => e.ClasseSocial)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("classe_social")
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.Property(e => e.Estado)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("estado")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            entity.Property(e => e.QuantidadePacientes).HasColumnName("quantidade_pacientes");
        });

        modelBuilder.Entity<ReiciendenciaMesesRegium>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("reiciendencia_meses_regia");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            entity.Property(e => e.Mes).HasColumnName("mes");

            entity.Property(e => e.NomeDoenca)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome_doenca")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.Property(e => e.Regiao)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("regiao")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.Property(e => e.Reicidencia).HasColumnName("reicidencia");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
