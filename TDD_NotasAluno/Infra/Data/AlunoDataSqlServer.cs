﻿using Microsoft.EntityFrameworkCore;
using TDD_NotasAluno.Application.Data;
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

        public async Task<Aluno> GetAlunoByIdAsync(int idAluno)
        {
            var aluno = await _context.Alunos.FirstOrDefaultAsync(x => x.Id == idAluno);

            if (aluno is not null)
            {
                return aluno;
            }
            else
            {
                throw new Exception("Não encontrado!");
            }
        }

        public async Task PutAlunoAsync(int idAluno, Aluno aluno)
        {
            if (idAluno == aluno.Id)
            {
                _context.Update(aluno);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Erro na requisição!");
            }
        }
    }
}
