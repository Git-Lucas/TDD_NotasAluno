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
            var result = await alunoService.GetMediaAlunoByIdAsync(idAluno);
            float media = (float)result.GetType().GetProperty("media")!.GetValue(result)!;
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
            var result = await alunoService.GetMediaAlunoByIdAsync(idAluno);
            float media = (float)result.GetType().GetProperty("media")!.GetValue(result)!;
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
            var result = await alunoService.GetMediaAlunoByIdAsync(idAluno);
            float media = (float)result.GetType().GetProperty("media")!.GetValue(result)!;
            Assert.Equal(8.9, Math.Round(media, 2));
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
            var result = await alunoService.GetMediaAlunoByIdAsync(idAluno);
            float media = (float)result.GetType().GetProperty("media")!.GetValue(result)!;
            Assert.Equal(8.9, Math.Round(media, 2));
        }
    }
}
