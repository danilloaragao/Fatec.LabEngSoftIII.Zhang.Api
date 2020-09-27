﻿using Fatec.LabEngSoftIII.Zhang.Api.Entidades.Entradas;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades.Saidas;
using Fatec.LabEngSoftIII.Zhang.Api.Handles;
using Fatec.LabEngSoftIII.Zhang.API.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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
        [Route("Palavra")]
        public ActionResult PegarPalavra([FromQuery] string tema)
        {

            return Ok(new RespPalavraJogo()
            {
                Id = 1,
                Palavra = "Mock",
                Dica1 = "Dica 1",
                Dica2 = "Dica 2",
                Letras = new List<string>()
                {
                    "M",
                    "O",
                    "C",
                    "K",
                    "A",
                    "S",
                    "D",
                    "F"
                }.OrderBy(l => l).ToList()
            });
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

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [Route("Skins")]
        public ActionResult AlteracaoSkins([FromBody] List<ReqSkin> skins, [FromHeader] string token)
        {
            try
            {
                if (!Token.Validar(token))
                    return StatusCode(401, $"Usuário não autorizado para essa operação");

                return Ok(JogoHandler.AlteracaoSkins(skins, Token.PegarId(token)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }
    }
}
