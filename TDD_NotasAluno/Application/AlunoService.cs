using TDD_NotasAluno.Application.Data;

namespace TDD_NotasAluno.Application
{
    public class AlunoService
    {
        private readonly IAlunoData _alunoData;
        private readonly INotaData _notaData;

        public AlunoService(IAlunoData alunoData, INotaData notaData)
        {
            _alunoData = alunoData;
            _notaData = notaData;
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
                var aluno = await _alunoData.GetAlunoByIdAsync(idAluno);

                aluno.Notas = await _notaData.GetNotasByIdAlunoAsync(idAluno);
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
