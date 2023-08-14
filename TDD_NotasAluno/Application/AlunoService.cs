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

        //USE CASE
        public async Task<float> GetMediaAlunoByIdAsync(int idAluno)
        {
            try
            {
                var aluno = await _alunoData.GetAlunoByIdAsync(idAluno);

                return aluno.Media;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //USE CASE
        public async Task CalcularMediaAsync(int idAluno)
        {
            try
            {
                var aluno = await _alunoData.GetAlunoByIdAsync(idAluno, true);

                aluno.CalcularMedia();

                await _alunoData.PutAlunoAsync(idAluno, aluno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
