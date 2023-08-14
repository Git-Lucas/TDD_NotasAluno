using Microsoft.AspNetCore.Mvc;
using TDD_NotasAluno.Application;

namespace TDD_NotasAluno.Controllers
{
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly AlunoService _alunoService;

        public AlunosController(AlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet("/alunos/{idAluno}")]
        public async Task<IActionResult> GetMediaAlunoByIdAsync([FromRoute] int idAluno)
        {
            try
            {
                return Ok(await _alunoService.GetMediaAlunoByIdAsync(idAluno));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/alunos/{idAluno}/calculaMedia")]
        public async Task<IActionResult> CalcularMedia([FromRoute] int idAluno)
        {
            try
            {
                await _alunoService.CalcularMediaAsync(idAluno);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
