using TDD_NotasAluno.Application.Data;
using TDD_NotasAluno.Domain.Model;

namespace TDD_NotasAluno.Tests.Integration
{
    public class NotaDataMemory : INotaData
    {
        public static Aluno Aluno { get; set; } = new()
        {
            Id = 1,
            Nome = "Lucas de Oliveira",
            CodigoCurso = "CCCAT12",
            Media = 0
        };

        public List<Nota> Notas { get; set; } = new()
        {
            new()
            {
                Id = 1,
                Aluno = Aluno,
                CodigoExame = "E1",
                ValorNota = 10,
                PesoNota = (float)0.3
            },
            new()
            {
                Id = 2,
                Aluno = Aluno,
                CodigoExame = "E2",
                ValorNota = 9,
                PesoNota = (float)0.3
            },
            new()
            {
                Id = 3,
                Aluno = Aluno,
                CodigoExame = "E3",
                ValorNota = 8,
                PesoNota = (float)0.4
            }
        };

        public async Task<List<Nota>> GetNotasByIdAlunoAsync(int idAluno)
        {
            var notas = Notas.Where(x => x.Aluno.Id == idAluno).ToList();

            if (notas.Any())
            {
                return notas;
            }
            else
            {
                throw new Exception("Sem notas para este usuário.");
            }

        }
    }
}
