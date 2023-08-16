namespace TDD_NotasAluno.Tests.Unit
{
    public class AlunoTest
    {
        [Fact]
        public void CalcularMediaSimplesAluno()
        {
            //DADO
            Aluno aluno = new()
            {
                Id = 1,
                Nome = "Lucas de Oliveira",
                CodigoCurso = "CCCAT12",
                Media = 0,
                Notas = new()
                {
                    new()
                    {
                        Id = 1,
                        CodigoExame = "E1",
                        ValorNota = 10,
                        PesoNota = (float)0.3
                    },
                    new()
                    {
                        Id = 2,
                        CodigoExame = "E2",
                        ValorNota = 9,
                        PesoNota = (float)0.3
                    },
                    new()
                    {
                        Id = 3,
                        CodigoExame = "E3",
                        ValorNota = 8,
                        PesoNota = (float)0.4
                    }
                }
            };
            ICalcularMedia calcularMedia = new CalcularMediaSimples();

            //QUANDO
            calcularMedia.CalcularMedia(aluno);

            //ENTÃO
            Assert.Equal(9, aluno.Media);
        }

        [Fact]
        public void CalcularMediaPonderadaAluno()
        {
            //DADO
            Aluno aluno = new()
            {
                Id = 1,
                Nome = "Lucas de Oliveira",
                CodigoCurso = "CCCAT12",
                Media = 0,
                Notas = new()
                {
                    new()
                    {
                        Id = 1,
                        CodigoExame = "E1",
                        ValorNota = 10,
                        PesoNota = (float)0.3
                    },
                    new()
                    {
                        Id = 2,
                        CodigoExame = "E2",
                        ValorNota = 9,
                        PesoNota = (float)0.3
                    },
                    new()
                    {
                        Id = 3,
                        CodigoExame = "E3",
                        ValorNota = 8,
                        PesoNota = (float)0.4
                    }
                }
            };
            ICalcularMedia calcularMedia = new CalcularMediaPonderada();

            //QUANDO
            calcularMedia.CalcularMedia(aluno);

            //ENTÃO
            Assert.Equal(8.90, Math.Round(aluno.Media, 2));
        }
    }
}
