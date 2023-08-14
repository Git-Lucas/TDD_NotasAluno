using TDD_NotasAluno.Application;
using TDD_NotasAluno.Application.Data;
using TDD_NotasAluno.Infra.Data;

namespace TDD_NotasAluno.Tests.Integration
{
    public class AlunoServiceTest
    {
        //Broad Integration Test
        [Fact]
        public async void CalcularMediaAlunoSqlServer()
        {
            //DADO
            int idAluno = 1;
            IAlunoData alunoData = new AlunoDataSqlServer(new EfSqlServerAdapter());
            INotaData notaData = new NotaDataSqlServer(new EfSqlServerAdapter());
            AlunoService alunoService = new AlunoService(alunoData, notaData);

            //QUANDO
            await alunoService.CalcularMediaAsync(idAluno);

            //ENTÃO
            var media = await alunoService.GetMediaAlunoByIdAsync(idAluno);
            Assert.Equal(9, media);
        }

        //Narrow Integration Test
        [Fact]
        public async void CalcularMediaAlunoMemory()
        {
            //DADO
            int idAluno = 1;
            IAlunoData alunoData = new AlunoDataMemory();
            INotaData notaData = new NotaDataMemory();
            AlunoService alunoService = new AlunoService(alunoData, notaData);

            //QUANDO
            await alunoService.CalcularMediaAsync(idAluno);

            //ENTÃO
            var media = await alunoService.GetMediaAlunoByIdAsync(idAluno);
            Assert.Equal(9, media);
        }
    }
}
