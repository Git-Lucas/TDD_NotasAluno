using TDD_NotasAluno.Domain.Data;

namespace TDD_NotasAluno.Application
{
    public class AlunoService
    {
        private readonly IAlunoData _alunoData;

        public AlunoService(IAlunoData alunoData)
        {
            _alunoData = alunoData;
        }

        public async Task<float> GetMediaAlunoByIdAsync(int idAluno)
        {
            try
            {
                return await _alunoData.GetMediaAlunoByIdAsync(idAluno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }  

        public async Task CalcularMediaAsync(int idAluno)
        {
            try
            {
                await _alunoData.CalcularMediaAsync(idAluno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
