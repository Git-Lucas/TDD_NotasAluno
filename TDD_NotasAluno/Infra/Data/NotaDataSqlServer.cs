using Microsoft.EntityFrameworkCore;
using TDD_NotasAluno.Application.Data;
using TDD_NotasAluno.Domain.Model;

namespace TDD_NotasAluno.Infra.Data
{
    public class NotaDataSqlServer : INotaData
    {
        private readonly EfSqlServerAdapter _context;

        public NotaDataSqlServer(EfSqlServerAdapter context)
        {
            _context = context;
        }

        public async Task<List<Nota>> GetNotasByIdAlunoAsync(int idAluno)
        {
            var notas = await _context.Notas.Where(x => x.AlunoId == idAluno).ToListAsync();

            if (notas.Any())
            {
                return notas;
            }
            else
            {
                throw new Exception("Sem notas para este usuário.");
            }
        }
    }
}
