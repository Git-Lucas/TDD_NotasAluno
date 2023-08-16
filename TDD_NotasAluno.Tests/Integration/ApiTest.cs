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
            var json = JsonConvert.SerializeObject(tipoCalculoMedia);
            StringContent httpContent = new StringContent(json);

            await HttpClient.PostAsync($"/alunos/{idAluno}/calculaMedia", httpContent);

            //Quando
            var response = await HttpClient.GetAsync($"/alunos/{idAluno}");

            //Então
            var output = await response.Content.ReadAsStringAsync();
            var media = JsonConvert.DeserializeObject<float>(output);
            Assert.Equal(9, media);
        }

        [Fact]
        public async void CalcularMediaPonderadaDeAluno()
        {
            //TEST_FIRST:
            //Dado
            int idAluno = 1;
            string tipoCalculoMedia = "ponderada";
            var json = JsonConvert.SerializeObject(tipoCalculoMedia);
            StringContent httpContent = new StringContent(json);

            await HttpClient.PostAsync($"/alunos/{idAluno}/calculaMedia", httpContent);

            //Quando
            var response = await HttpClient.GetAsync($"/alunos/{idAluno}");

            //Então
            var output = await response.Content.ReadAsStringAsync();
            var media = JsonConvert.DeserializeObject<float>(output);
            Assert.Equal(9, media);
        }
    }
}