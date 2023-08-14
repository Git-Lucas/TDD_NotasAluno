using Microsoft.EntityFrameworkCore;
using TDD_NotasAluno.Domain.Data;
using TDD_NotasAluno.Domain.Model;

namespace TDD_NotasAluno.Infra.Data
{
    public class AlunoDataSqlServer : IAlunoData
    {
        private readonly EfSqlServerAdapter _context;

        public AlunoDataSqlServer(EfSqlServerAdapter context)
        {
            _context = context;
        }

        public async Task<float> GetMediaAlunoByIdAsync(int idAluno)
        {
            var aluno = await _context.Alunos.FirstOrDefaultAsync(x => x.Id == idAluno);

            if (aluno is not null)
            {
                return aluno.Media;
            }
            else
            {
                throw new Exception("Não encontrado!");
            }

        }

        public async Task CalcularMediaAsync(int idAluno)
        {
            var aluno = await _context.Alunos.Include(x => x.Notas)
                                             .FirstOrDefaultAsync(x => x.Id == idAluno);

            if (aluno is not null)
            {
                aluno.CalcularMedia();

                _context.Update(aluno);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Não encontrado!");
            }
        }
    }
}
