﻿using Fatec.LabEngSoftIII.Zhang.Api.Entidades.Entradas;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades.Saidas;
using Fatec.LabEngSoftIII.Zhang.Api.Handles;
using Fatec.LabEngSoftIII.Zhang.Api.Utils;
using Fatec.LabEngSoftIII.Zhang.API.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Fatec.LabEngSoftIII.Zhang.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private readonly JogoHandler JogoHandler = new JogoHandler();
        private readonly Token Token = new Token();

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type= typeof(RespPalavraJogo))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type= typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type= typeof(string))]
        [Route("Palavra")]
        public ActionResult PegarPalavra([FromQuery] string tema, [FromHeader] string token)
        {
            try
            {
                int idUsuario = 0;

                if (!string.IsNullOrWhiteSpace(token) && Token.Validar(token))
                    idUsuario = Token.PegarId(token);

                    RespPalavraJogo resposta = JogoHandler.ObterPalavra(tema, idUsuario);

                if (resposta == null)
                    return StatusCode(400, "Ocorreu uma falha no processamento. Tente novamente dentro de instantes.");

                return Ok(resposta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RespUsuario))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(String))]
        [Route("Acerto")]
        public ActionResult Acerto([FromBody] ReqAcerto acerto, [FromHeader] string token)
        {
            try
            {
                if (!Token.Validar(token))
                    return Ok("Jogador convidado.");

                RespUsuario resposta = JogoHandler.AcertoPalavra(acerto, Token.PegarId(token));

                if(resposta == null)
                    return StatusCode(400 ,"Ocorreu uma falha no processamento. A palavra acertada não pode ser lida.");

                return Ok(resposta);
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
        [Route("CompraSkin")]
        public ActionResult CompraSkin([FromQuery] int idSkin, [FromHeader] string token)
        {
            try
            {
                if (!Token.Validar(token))
                    return StatusCode(401, $"Usuário não autorizado para essa operação");

                RespUsuario resposta = JogoHandler.CompraSkin(idSkin, Token.PegarId(token));

                if (resposta == null)
                    return StatusCode(400, "Ocorreu uma falha no processamento. Tente novamente mais tarde.");

                return Ok(resposta);
            }
            catch (CashInsuficienteException ex)
            {
                return StatusCode(401, ex.Message);
            }
            catch (SkinObtidaException ex)
            {
                return StatusCode(401, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RespUsuario))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [Route("Skins")]
        public ActionResult AlteracaoSkins([FromQuery] int idSkin, [FromHeader] string token)
        {
            try
            {
                if (!Token.Validar(token))
                    return StatusCode(401, $"Usuário não autorizado para essa operação");

                return Ok(JogoHandler.AlteracaoSkin(idSkin, Token.PegarId(token)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<RespSkin>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [Route("Skins")]
        public ActionResult SkinsUsuario([FromHeader] string token)
        {
            try
            {
                if (!Token.Validar(token))
                    return StatusCode(401, $"Usuário não autorizado para essa operação");

                return Ok(JogoHandler.ObterSkinsUsuario(Token.PegarId(token)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<RespRanking>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [Route("Ranking")]
        public ActionResult Ranking([FromHeader] string token)
        {
            try
            {
                if (!Token.Validar(token))
                    return StatusCode(401, $"Usuário não autorizado para essa operação");

                return Ok(JogoHandler.Ranking(Token.PegarId(token)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [Route("CompraCash")]
        public ActionResult CompraCash([FromBody] int qtdCash,[FromHeader] string token)
        {
            try
            {
                if (!Token.Validar(token))
                    return StatusCode(401, $"Usuário não autorizado para essa operação");

                return Ok(JogoHandler.CompraCash(qtdCash, Token.PegarId(token)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<RespSkinVip>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [Route("SkinsVip")]
        public ActionResult SkinsVip([FromHeader] string token)
        {
            try
            {
                if (!Token.Validar(token))
                    return StatusCode(401, $"Usuário não autorizado para essa operação");

                return Ok(JogoHandler.SkinsVip(Token.PegarId(token)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }
    }
}
