using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades.Entradas;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades.Saidas;
using Fatec.LabEngSoftIII.Zhang.Api.Handles;
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [Route("Cadastro")]
        public ActionResult Cadastro([FromBody] Usuario usuario)
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
            return Ok("Sua senha foi enviada para o e-mail cadastrado");
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RespUsuario))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [Route("Login")]
        public ActionResult Login([FromBody] ReqCredenciais credenciais)
        {
            RespUsuario resp = UsuarioHandler.Login(credenciais);

            if (resp == null)
                return StatusCode(401, "Usuário ou senha invalido");

            return Ok(resp);
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [Route("AlterarDados")]
        public ActionResult AlterarDados([FromBody] Usuario usuario)
        {
            return Ok("Dados atualizados com sucesso");
        }
    }
}
