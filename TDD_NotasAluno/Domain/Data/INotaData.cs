using TDD_NotasAluno.Domain.Model;

namespace TDD_NotasAluno.Domain.Data
{
    public interface INotaData
    {
        Task<List<Nota>> GetNotasByIdAlunoAsync(int idAluno);
    }
}
