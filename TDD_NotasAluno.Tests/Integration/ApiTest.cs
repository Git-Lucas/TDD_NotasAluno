namespace TDD_NotasAluno.Tests.Integration
{
    public class ApiTest
    {
        static HttpClient HttpClient = new() { BaseAddress = new Uri("http://localhost:5033") };

        [Fact]
        public async void CalcularMediaDeAluno()
        {
            //TEST_FIRST:
            //Dado
            int idAluno = 1;
            await HttpClient.PostAsync($"/alunos/{idAluno}/calculaMedia", null);

            //Quando
            var response = await HttpClient.GetAsync($"/alunos/{idAluno}");

            //Então
            var output = await response.Content.ReadAsStringAsync();
            var media = JsonConvert.DeserializeObject<float>(output);
            Assert.Equal(9, media);
        }
    }
}