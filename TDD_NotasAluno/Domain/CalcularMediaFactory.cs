namespace TDD_NotasAluno.Domain
{
    public class CalcularMediaFactory
    {
        public static ICalcularMedia Create(string tipoCalculoMedia)
        {
            if (tipoCalculoMedia == "simples")
            {
                return new CalcularMediaSimples();
            }
            if (tipoCalculoMedia == "ponderada")
            {
                return new CalcularMediaPonderada();
            }
            throw new Exception("Tipo inválido.");
        }
    }
}
