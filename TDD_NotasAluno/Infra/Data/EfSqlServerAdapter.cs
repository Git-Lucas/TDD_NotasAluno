using Microsoft.EntityFrameworkCore;
using TDD_NotasAluno.Domain.Model;

namespace TDD_NotasAluno.Infra.Data
{
    public class EfSqlServerAdapter : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Nota> Notas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TDD_NotasAlunoBd;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().HasData(new Aluno()
            {
                Id = 1,
                Nome = "Lucas de Oliveira",
                CodigoCurso = "CCCAT12",
                Media = 0
            });

            modelBuilder.Entity<Nota>().HasData(
                new
                {
                    Id = 1,
                    AlunoId = 1,
                    CodigoExame = "E1",
                    ValorNota = (float)10,
                    PesoNota = (float)0.3
                },
                new
                {
                    Id = 2,
                    AlunoId = 1,
                    CodigoExame = "E2",
                    ValorNota = (float)9,
                    PesoNota = (float)0.3
                },
                new
                {
                    Id = 3,
                    AlunoId = 1,
                    CodigoExame = "E3",
                    ValorNota = (float)8,
                    PesoNota = (float)0.4
                });
        }
    }
}
