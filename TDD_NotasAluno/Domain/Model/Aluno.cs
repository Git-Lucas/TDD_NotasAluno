namespace TDD_NotasAluno.Domain.Model
{
    public class Aluno
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? CodigoCurso { get; set; }
        public float Media { get; set; } = 0;
        public List<Nota> Notas { get; set; } = new();
    }
}
