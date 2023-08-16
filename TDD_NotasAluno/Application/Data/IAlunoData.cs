using TDD_NotasAluno.Domain.Model;

namespace TDD_NotasAluno.Application.Data
{
    //A interface para dados de "Aluno" e "Nota" foram movidas
    //para a camada de aplicação, por considerar que a implementação
    //é na camada de infraestrutura. A camada de domínio não o utiliza
    //em momento algum. Portanto, é correto dizer que estas interfaces
    //estão entre a camada de domínio e a camada de infraestrutura
    //(camada de aplicação)
    public interface IAlunoData
    {
        Task<Aluno> GetAlunoByIdAsync(int idAluno);
        Task PutAlunoAsync(int idAluno, Aluno aluno);
    }
}
