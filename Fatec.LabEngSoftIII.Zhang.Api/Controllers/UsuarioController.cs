using Fatec.LabEngSoftIII.Zhang.Api.Entidades.Entradas;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades.Saidas;
using Fatec.LabEngSoftIII.Zhang.Api.Handles;
using Fatec.LabEngSoftIII.Zhang.API.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Fatec.LabEngSoftIII.Zhang.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioHandler UsuarioHandler = new UsuarioHandler();
        private readonly Token Token = new Token();

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [Route("Cadastro")]
        public ActionResult Cadastro([FromBody] ReqCadastro usuario)
        {
            try
            {
                return Ok(this.UsuarioHandler.Cadastro(usuario));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [Route("RecuperacaoSenha")]
        public ActionResult RecuperacaoSenha([FromBody] string LoginEmail)
        {
            try
            {
                return StatusCode(200, UsuarioHandler.LembrarSenha(LoginEmail));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RespUsuario))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [Route("Login")]
        public ActionResult Login([FromBody] ReqCredenciais credenciais)
        {
            try
            {
                RespUsuario resp = UsuarioHandler.Login(credenciais);

                if (resp == null)
                    return StatusCode(401, "Usuário ou senha invalido");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [Route("AlterarDados")]
        public ActionResult AlterarDados([FromBody] ReqAtualizacaoUsuario usuario, [FromHeader] string token)
        {
            try
            {
                if (!Token.Validar(token) || usuario.Id != Token.PegarId(token))
                    return StatusCode(401, $"Usuário não autorizado para essa operação");

                string resposta = UsuarioHandler.AtualizarUsuario(usuario);

                return Ok(resposta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }
    }
}
