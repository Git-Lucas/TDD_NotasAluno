using TDD_NotasAluno.Application.Data;
using TDD_NotasAluno.Domain;

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
        public async Task<object> GetMediaAlunoByIdAsync(int idAluno)
        {
            try
            {
                var aluno = await _alunoData.GetAlunoByIdAsync(idAluno);
                var media = aluno.Media;
                var notas = await _notaData.GetNotasByIdAlunoAsync(idAluno);
                notas.ForEach(x => x.Aluno = null);

                return new
                {
                    media,
                    notas
                };

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //USE CASE
        public async Task CalcularMediaAsync(int idAluno, string tipoCalculoMedia)
        {
            try
            {
                var aluno = await _alunoData.GetAlunoByIdAsync(idAluno);

                aluno.Notas = await _notaData.GetNotasByIdAlunoAsync(idAluno);
                CalcularMediaFactory.Create(tipoCalculoMedia).CalcularMedia(aluno);

                await _alunoData.PutAlunoAsync(idAluno, aluno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
