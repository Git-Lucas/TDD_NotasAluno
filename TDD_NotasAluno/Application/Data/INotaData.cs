using TDD_NotasAluno.Domain.Model;

namespace TDD_NotasAluno.Application.Data
{
    public interface INotaData
    {
        Task<List<Nota>> GetNotasByIdAlunoAsync(int idAluno);
    }
}
