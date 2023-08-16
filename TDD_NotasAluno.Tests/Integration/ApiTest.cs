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
            dynamic obj = JsonConvert.DeserializeObject<ExpandoObject>(output)!;

            float media = (float)obj.media;
            Assert.Equal(9, media);

            var notas = obj.notas;
            Assert.Equal(3, notas.Count);
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
            dynamic obj = JsonConvert.DeserializeObject<ExpandoObject>(output)!;

            float media = (float)obj.media;
            Assert.Equal(8.90, Math.Round(media, 2));

            var notas = obj.notas;
            Assert.Equal(3, notas.Count);
        }
    }
}