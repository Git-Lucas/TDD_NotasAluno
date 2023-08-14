namespace TDD_NotasAluno.Domain.Data
{
    public interface IAlunoData
    {
        Task<float> GetMediaAlunoByIdAsync(int idAluno);
        Task CalcularMediaAsync(int idAluno);
    }
}
