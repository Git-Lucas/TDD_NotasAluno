namespace TDD_NotasAluno.Tests.Integration
{
    public class ApiTest
    {
        static HttpClient HttpClient = new() { BaseAddress = new Uri("http://localhost:5033") };

        [Fact]
        public async void CalcularMediaSimplesDeAluno()
        {
            //TEST_FIRST:
            //Dado
            int idAluno = 1;
            string tipoCalculoMedia = "simples";

            await HttpClient.PostAsJsonAsync($"/alunos/{idAluno}/calculaMedia", tipoCalculoMedia);

            //Quando
            var response = await HttpClient.GetAsync($"/alunos/{idAluno}");

            //Então
            var output = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<object>(output);
            float media = (float)result!.GetType().GetProperty("media")!.GetValue(result)!;
            Assert.Equal(9, media);
        }

        [Fact]
        public async void CalcularMediaPonderadaDeAluno()
        {
            //TEST_FIRST:
            //Dado
            int idAluno = 1;
            string tipoCalculoMedia = "ponderada";

            await HttpClient.PostAsJsonAsync($"/alunos/{idAluno}/calculaMedia", tipoCalculoMedia);

            //Quando
            var response = await HttpClient.GetAsync($"/alunos/{idAluno}");

            //Então
            var output = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<object>(output);
            float media = (float)result!.GetType().GetProperty("media")!.GetValue(result)!;
            Assert.Equal(8.90, Math.Round(media, 2));
        }
    }
}