using TDD_NotasAluno.Domain.Model;

namespace TDD_NotasAluno.Domain
{
    public class CalcularMediaPonderada : ICalcularMedia
    {
        public void CalcularMedia(Aluno aluno)
        {
            aluno.Media = 0;
            foreach (var nota in aluno.Notas)
            {
                aluno.Media += nota.ValorNota * nota.PesoNota;
            }
        }
    }
}
