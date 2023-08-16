namespace TDD_NotasAluno.Tests.Integration
{
    public class AlunoServiceTest
    {
        //Broad Integration Test
        [Fact]
        public async void CalcularMediaSimplesAlunoSqlServer()
        {
            //DADO
            int idAluno = 1;
            IAlunoData alunoData = new AlunoDataSqlServer(new EfSqlServerAdapter());
            INotaData notaData = new NotaDataSqlServer(new EfSqlServerAdapter());
            ICalcularMedia calcularMedia = new CalcularMediaSimples();
            AlunoService alunoService = new(alunoData, notaData, calcularMedia);

            //QUANDO
            await alunoService.CalcularMediaAsync(idAluno);

            //ENTÃO
            var media = await alunoService.GetMediaAlunoByIdAsync(idAluno);
            Assert.Equal(9, media);
        }

        //Narrow Integration Test
        [Fact]
        public async void CalcularMediaSimplesAlunoMemory()
        {
            //DADO
            int idAluno = 1;
            IAlunoData alunoData = new AlunoDataMemory();
            INotaData notaData = new NotaDataMemory();
            ICalcularMedia calcularMedia = new CalcularMediaSimples();
            AlunoService alunoService = new(alunoData, notaData, calcularMedia);

            //QUANDO
            await alunoService.CalcularMediaAsync(idAluno);

            //ENTÃO
            var media = await alunoService.GetMediaAlunoByIdAsync(idAluno);
            Assert.Equal(9, media);
        }
    }
}
