﻿using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades.Entradas;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades.Saidas;
using Fatec.LabEngSoftIII.Zhang.Api.Handles;
using Fatec.LabEngSoftIII.Zhang.API.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Fatec.LabEngSoftIII.Zhang.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministracaoController : ControllerBase
    {
        readonly private PalavraHandler PalavraHandler = new PalavraHandler();
        readonly private TemaHandler TemaHandler = new TemaHandler();
        readonly private ExperienciaHandler ExperienciaHandler = new ExperienciaHandler();
        readonly private SkinHandler SkinHandler = new SkinHandler();
        readonly private SuperUsuarioHandler SuperUsuarioHandler = new SuperUsuarioHandler();
        readonly private Token Token = new Token();

        #region Palavras
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PalavraJogo>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [Route("Palavras")]
        public ActionResult PegarTodasPalavras([FromHeader] string token)
        {
            try
            {
                if (!Token.ValidarAdm(token))
                    return StatusCode(401, $"Usuário não autorizado para essa operação");

                List<PalavraJogo> palavras = this.PalavraHandler.PegarTodasPalavras();

                if (palavras == null || palavras.Count == 0)
                    return NotFound("Não existem palavras no banco de dados.");

                return Ok(palavras);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [Route("Palavra")]
        public ActionResult InserePalavra([FromBody] PalavraJogo palavra, [FromHeader] string token)
        {
            try
            {
                if (!Token.ValidarAdm(token))
                    return StatusCode(401, $"Usuário não autorizado para essa operação");

                string resultado = this.PalavraHandler.InserePalavra(palavra);
                return Ok(resultado);
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
        [Route("Palavra")]
        public ActionResult AlteraPalavra([FromBody] PalavraJogo palavra, [FromHeader] string token)
        {
            try
            {
                if (!Token.ValidarAdm(token))
                    return StatusCode(401, $"Usuário não autorizado para essa operação");

                string resultado = this.PalavraHandler.AlteraPalavra(palavra);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [Route("Palavra/{idPalavra}")]
        public ActionResult DeletaPalavra(int idPalavra, [FromHeader] string token)
        {
            try
            {
                if (!Token.ValidarAdm(token))
                    return StatusCode(401, $"Usuário não autorizado para essa operação");

                string resultado = this.PalavraHandler.DeletaPalavra(idPalavra);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }
        #endregion

        #region Temas
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Tema>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [Route("Temas")]
        public ActionResult PegarTemas([FromHeader] string token)
        {
            try
            {
                if (!Token.ValidarAdm(token))
                    return StatusCode(401, $"Usuário não autorizado para essa operação");

                List<Tema> temas = this.TemaHandler.PegarTemas();

                if (temas == null || temas.Count == 0)
                    return NotFound("Não existem temas no banco de dados.");

                return Ok(temas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [Route("Tema")]
        public ActionResult InsereTema([FromBody] Tema tema, [FromHeader] string token)
        {
            try
            {
                if (!Token.ValidarAdm(token))
                    return StatusCode(401, $"Usuário não autorizado para essa operação");

                string resultado = this.TemaHandler.InsereTema(tema);
                return Ok(resultado);
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
        [Route("Tema")]
        public ActionResult AlteraTema([FromBody] Tema tema, [FromHeader] string token)
        {
            try
            {
                if (!Token.ValidarAdm(token))
                    return StatusCode(401, $"Usuário não autorizado para essa operação");

                string resultado = this.TemaHandler.AlteraTema(tema);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [Route("Tema/{idTema}")]
        public ActionResult DeletaTema(int idTema, [FromHeader] string token)
        {
            try
            {
                if (!Token.ValidarAdm(token))
                    return StatusCode(401, $"Usuário não autorizado para essa operação");

                string resultado = this.TemaHandler.DeletaTema(idTema);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }
        #endregion

        #region Experiencia
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Experiencia>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [Route("Experiencia")]
        public ActionResult PegarExperiencia([FromHeader] string token)
        {
            try
            {
                if (!Token.ValidarAdm(token))
                    return StatusCode(401, $"Usuário não autorizado para essa operação");

                List<Experiencia> experiencias = this.ExperienciaHandler.PegarExperiencias();

                if (experiencias == null || experiencias.Count == 0)
                    return NotFound("Não existem experiencias no banco de dados.");

                return Ok(experiencias);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [Route("Experiencia")]
        public ActionResult InsereExperiencia([FromBody] Experiencia experiencia, [FromHeader] string token)
        {
            try
            {
                if (!Token.ValidarAdm(token))
                    return StatusCode(401, $"Usuário não autorizado para essa operação");

                string resultado = this.ExperienciaHandler.InsereExperiencia(experiencia);
                return Ok(resultado);
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
        [Route("Experiencia")]
        public ActionResult AlteraExperiencia([FromBody] Experiencia experiencia, [FromHeader] string token)
        {
            try
            {
                if (!Token.ValidarAdm(token))
                    return StatusCode(401, $"Usuário não autorizado para essa operação");

                string resultado = this.ExperienciaHandler.AlteraExperiencia(experiencia);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [Route("Experiencia/{idExperiencia}")]
        public ActionResult DeletaExperiencia(int idExperiencia, [FromHeader] string token)
        {
            try
            {
                if (!Token.ValidarAdm(token))
                    return StatusCode(401, $"Usuário não autorizado para essa operação");

                string resultado = this.ExperienciaHandler.DeletaExperiencia(idExperiencia);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }
        #endregion

        #region Skins
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Skin>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [Route("Skins")]
        public ActionResult PegarSkins([FromHeader] string token)
        {
            try
            {
                if (!Token.ValidarAdm(token))
                    return StatusCode(401, $"Usuário não autorizado para essa operação");

                List<Skin> skins = this.SkinHandler.PegarSkins();

                if (skins == null || skins.Count == 0)
                    return NotFound("Não existem skins no banco de dados.");

                return Ok(skins);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [Route("Skin")]
        public ActionResult InsereSkin([FromBody] Skin skin, [FromHeader] string token)
        {
            try
            {
                if (!Token.ValidarAdm(token))
                    return StatusCode(401, $"Usuário não autorizado para essa operação");

                string resultado = this.SkinHandler.InsereSkin(skin);
                return Ok(resultado);
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
        [Route("Skin")]
        public ActionResult AlteraSkin([FromBody] Skin skin, [FromHeader] string token)
        {
            try
            {
                if (!Token.ValidarAdm(token))
                    return StatusCode(401, $"Usuário não autorizado para essa operação");

                string resultado = this.SkinHandler.AlteraSkin(skin);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [Route("Skin/{idSkin}")]
        public ActionResult DeletaSkin(int idSkin, [FromHeader] string token)
        {
            try
            {
                if (!Token.ValidarAdm(token))
                    return StatusCode(401, $"Usuário não autorizado para essa operação");

                string resultado = this.SkinHandler.DeletaSkin(idSkin);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }
        #endregion

        #region Administradores
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RespAdm))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [Route("LoginAdm")]
        public ActionResult Login([FromBody] ReqCredenciais credenciais)
        {
            try
            {
                RespAdm resp = SuperUsuarioHandler.Login(credenciais);

                if (resp == null)
                    return StatusCode(401, "Usuário ou senha invalido");

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [Route("CadastroAdm")]
        public ActionResult CadastroAdm([FromBody] ReqCadastroAdm usuario, [FromHeader] string token)
        {
            try
            {
                if (!Token.ValidarAdm(token))
                    return StatusCode(401, $"Usuário não autorizado para essa operação");


                return Ok(this.SuperUsuarioHandler.Cadastro(usuario));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }

        }
        #endregion
    }
}
