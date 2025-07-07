using GerenciadorUsuarios.Dominio.Comunicacao;
using GerenciadorUsuarios.Dominio.Comunicacao.DTOs.Usuario;
using GerenciadorUsuarios.Dominio.Comunicacao.Factory;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorUsuarios.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class UsuarioController(IMediator mediator) : ControllerBase
    {
        private IMediator _mediator = mediator;

        [AllowAnonymous]
        [HttpPost("auto-cadastro")]
        public async Task<IActionResult> AutoCadastro([FromBody] AutoCadastroReq request)
        {
            var resultado = await _mediator.Send(
                CommandFactory.Create<AutoCadastroReq, ResultadoGenerico<long>>(request));

            if (!resultado.Sucesso)
                return BadRequest(resultado);

            return Ok(resultado);
        }
    }
}
