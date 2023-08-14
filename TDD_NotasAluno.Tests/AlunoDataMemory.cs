using Microsoft.EntityFrameworkCore;
using TDD_NotasAluno.Application.Data;
using TDD_NotasAluno.Domain.Model;

namespace TDD_NotasAluno.Tests
{
    public class AlunoDataMemory : IAlunoData
    {
        public List<Aluno> Alunos { get; set; } = new()
        {
            new(){
                Id = 1,
                Nome = "Lucas de Oliveira",
                CodigoCurso = "CCCAT12",
                Media = 0
            }
        };

        public async Task<Aluno> GetAlunoByIdAsync(int idAluno)
        {
            var aluno = Alunos.FirstOrDefault(x => x.Id == idAluno);
            if (aluno is not null)
            {
                return aluno;
            }
            else
            {
                throw new Exception("Não encontrado.");
            }
        }

        public async Task PutAlunoAsync(int idAluno, Aluno aluno)
        {
            if (idAluno == aluno.Id)
            {
                var alunoMemory = await GetAlunoByIdAsync(idAluno);

                alunoMemory.Media = aluno.Media;
            }
            else
            {
                throw new Exception("Erro na requisição!");
            }
        }
    }
}
