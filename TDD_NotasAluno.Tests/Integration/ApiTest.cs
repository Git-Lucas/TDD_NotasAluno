namespace TDD_NotasAluno.Tests.Integration
{
    //N�o � necess�rio testar todos os casos do teste unit�rio, pois o comportamento interno
    //j� foi testado.
    //Este deve focar realmente na integra��o dos recursos �s l�gicas de dom�nio
    public class ApiTest
    {
        static HttpClient HttpClient = new() { BaseAddress = new Uri("http://localhost:5033") };

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

            //Ent�o
            var output = await response.Content.ReadAsStringAsync();
            dynamic obj = JsonConvert.DeserializeObject<ExpandoObject>(output)!;

            float media = (float)obj.media;
            Assert.Equal(8.90, Math.Round(media, 2));

            var notas = obj.notas;
            Assert.Equal(3, notas.Count);
        }
    }
}