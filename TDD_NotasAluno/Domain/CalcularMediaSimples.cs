using TDD_NotasAluno.Domain.Model;

namespace TDD_NotasAluno.Domain
{
    public class CalcularMediaSimples : ICalcularMedia
    {
        public void CalcularMedia(Aluno aluno)
        {
            var totalNotas = (float)0;
            foreach (var nota in aluno.Notas)
            {
                totalNotas += nota.ValorNota;
            }

            aluno.Media = totalNotas / aluno.Notas.Count;
        }
    }
}
