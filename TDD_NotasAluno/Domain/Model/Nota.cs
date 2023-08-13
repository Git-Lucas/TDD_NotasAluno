namespace TDD_NotasAluno.Domain.Model
{
    public class Nota
    {
        public int Id { get; set; }
        public Aluno Aluno { get; set; }
        public string CodigoExame { get; set; }
        public float ValorNota { get; set; }
        public float PesoNota { get; set; }
    }
}
