using TDD_NotasAluno.Domain.Model;

namespace TDD_NotasAluno.Application.Data
{
    public interface IAlunoData
    {
        Task<Aluno> GetAlunoByIdAsync(int idAluno);
        Task PutAlunoAsync(int idAluno, Aluno aluno);
    }
}
