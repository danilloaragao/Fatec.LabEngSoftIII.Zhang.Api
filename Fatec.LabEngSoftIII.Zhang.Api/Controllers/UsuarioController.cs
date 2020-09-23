using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades.Entradas;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades.Saidas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Fatec.LabEngSoftIII.Zhang.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [Route("Cadastro")]
        public ActionResult Cadastro([FromBody] Usuario usuario)
        {
            return Ok("Cadastro efetuado com sucesso");
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
        [Route("Login")]
        public ActionResult Login([FromBody] ReqCredenciais credenciais)
        {
            RespUsuario resp = new RespUsuario()
            {
                Id = 1,
                Email = "mock@mock.com.br",
                Login = "Mock",
                Experiencia = 400,
                ExperienciaProximoNivel = 50,
                Nivel = 4,
                Skins = new List<RespSkin>()
                {
                    new RespSkin()
                    {
                        Id = 1,
                        Nivel = 1,
                        Descricao = "Skin 1",
                        Ativo = false
                    } ,
                    new RespSkin()
                    {
                        Id = 2,
                        Nivel = 2,
                        Descricao = "Skin 2",
                        Ativo = true
                    } ,
                    new RespSkin()
                    {
                        Id = 3,
                        Nivel = 3,
                        Descricao = "Skin 3",
                        Ativo = false
                    }
                },
                Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"

            };

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
