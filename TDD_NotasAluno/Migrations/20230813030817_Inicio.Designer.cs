﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TDD_NotasAluno.Infra.Data;

#nullable disable

namespace TDD_NotasAluno.Migrations
{
    [DbContext(typeof(EfSqlServerAdapter))]
    [Migration("20230813030817_Inicio")]
    partial class Inicio
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TDD_NotasAluno.Domain.Model.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoCurso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Media")
                        .HasColumnType("real");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Alunos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CodigoCurso = "CCCAT12",
                            Media = 0f,
                            Nome = "Lucas de Oliveira"
                        });
                });

            modelBuilder.Entity("TDD_NotasAluno.Domain.Model.Nota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<string>("CodigoExame")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PesoNota")
                        .HasColumnType("real");

                    b.Property<float>("ValorNota")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.ToTable("Notas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlunoId = 1,
                            CodigoExame = "E1",
                            PesoNota = 0.3f,
                            ValorNota = 10f
                        },
                        new
                        {
                            Id = 2,
                            AlunoId = 1,
                            CodigoExame = "E2",
                            PesoNota = 0.3f,
                            ValorNota = 9f
                        },
                        new
                        {
                            Id = 3,
                            AlunoId = 1,
                            CodigoExame = "E3",
                            PesoNota = 0.4f,
                            ValorNota = 8f
                        });
                });

            modelBuilder.Entity("TDD_NotasAluno.Domain.Model.Nota", b =>
                {
                    b.HasOne("TDD_NotasAluno.Domain.Model.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");
                });
#pragma warning restore 612, 618
        }
    }
}
