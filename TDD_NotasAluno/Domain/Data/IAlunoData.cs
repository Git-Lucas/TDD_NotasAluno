using TDD_NotasAluno.Domain.Model;

namespace TDD_NotasAluno.Domain.Data
{
    public interface IAlunoData
    {
        Task<Aluno> GetAlunoByIdAsync(int idAluno, bool include = false);
        Task PutAlunoAsync(int idAluno, Aluno aluno);
    }
}
