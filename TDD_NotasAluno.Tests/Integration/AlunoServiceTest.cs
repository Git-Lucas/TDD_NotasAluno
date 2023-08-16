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
            AlunoService alunoService = new(alunoData, notaData);

            //QUANDO
            await alunoService.CalcularMediaAsync(idAluno, "simples");

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
            AlunoService alunoService = new(alunoData, notaData);

            //QUANDO
            await alunoService.CalcularMediaAsync(idAluno, "simples");

            //ENTÃO
            var media = await alunoService.GetMediaAlunoByIdAsync(idAluno);
            Assert.Equal(9, media);
        }

        //Broad Integration Test
        [Fact]
        public async void CalcularMediaPonderadaAlunoSqlServer()
        {
            //DADO
            int idAluno = 1;
            IAlunoData alunoData = new AlunoDataSqlServer(new EfSqlServerAdapter());
            INotaData notaData = new NotaDataSqlServer(new EfSqlServerAdapter());
            AlunoService alunoService = new(alunoData, notaData);

            //QUANDO
            await alunoService.CalcularMediaAsync(idAluno, "ponderada");

            //ENTÃO
            var media = await alunoService.GetMediaAlunoByIdAsync(idAluno);
            Assert.Equal(8.90, Math.Round(media, 2));
        }

        //Narrow Integration Test
        [Fact]
        public async void CalcularMediaPonderadaAlunoMemory()
        {
            //DADO
            int idAluno = 1;
            IAlunoData alunoData = new AlunoDataMemory();
            INotaData notaData = new NotaDataMemory();
            AlunoService alunoService = new(alunoData, notaData);

            //QUANDO
            await alunoService.CalcularMediaAsync(idAluno, "ponderada");

            //ENTÃO
            var media = await alunoService.GetMediaAlunoByIdAsync(idAluno);
            Assert.Equal(8.90, Math.Round(media, 2));
        }
    }
}
