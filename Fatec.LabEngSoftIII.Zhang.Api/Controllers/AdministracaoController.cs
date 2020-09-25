using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
using Fatec.LabEngSoftIII.Zhang.Api.Handles;
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
        private PalavraHandler _palavraHandler = new PalavraHandler();
        private TemaHandler _temaHandler = new TemaHandler();

        #region Palavras
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PalavraJogo>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [Route("PalavrasPorTema")]
        public ActionResult PegarPalavrasPorTema([FromQuery] string tema)
        {
            try
            {
                List<PalavraJogo> palavras = this._palavraHandler.PegarPalavrasPorTema(tema);

                if (palavras == null)
                    return NotFound("Tema não encontrado no banco de dados.");

                if (palavras.Count == 0)
                    return NotFound("Não foram encontradas palavras para esse tema.");

                return Ok(palavras);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PalavraJogo))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [Route("PalavraPorId")]
        public ActionResult PegarPalavra([FromQuery] int id)
        {
            try
            {
                PalavraJogo palavra = this._palavraHandler.PegarPalavra(id);

                if (palavra == null)
                    return NotFound("Id não encontrado no banco de dados.");

                return Ok(palavra);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PalavraJogo>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [Route("PalavrasPorTrecho")]
        public ActionResult PegarPalavrasPorTrecho([FromQuery] string palavra)
        {
            try
            {
                List<PalavraJogo> palavras = this._palavraHandler.PegarPalavrasPorTrecho(palavra);

                if (palavras == null || palavras.Count == 0)
                    return NotFound("Palavra não encontrada no banco de dados.");

                return Ok(palavras);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PalavraJogo>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [Route("Palavras")]
        public ActionResult PegarTodasPalavras()
        {
            try
            {
                List<PalavraJogo> palavras = this._palavraHandler.PegarTodasPalavras();

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
        [Route("Palavra")]
        public ActionResult InserePalavra([FromBody] PalavraJogo palavra)
        {
            try
            {
                string resultado = this._palavraHandler.InserePalavra(palavra);
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
        [Route("Palavra")]
        public ActionResult AlteraPalavra([FromBody] PalavraJogo palavra)
        {
            try
            {
                string resultado = this._palavraHandler.AlteraPalavra(palavra);
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
        [Route("Palavra")]
        public ActionResult DeletaPalavra([FromBody] int idPalavra)
        {
            try
            {
                string resultado = this._palavraHandler.DeletaPalavra(idPalavra);
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Tema))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [Route("TemaPorId")]
        public ActionResult PegarTema([FromQuery] int id)
        {

            try
            {
                Tema tema = this._temaHandler.PegarTema(id);

                if (tema == null)
                    return NotFound("Id não encontrado no banco de dados.");

                return Ok(tema);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Tema>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [Route("TemasPorDescricao")]
        public ActionResult PegarTemasPorDescricao([FromQuery] string tema)
        {
            try
            {
                List<Tema> temas = this._temaHandler.PegarTemasPorDescricao(tema);

                if (temas == null || temas.Count == 0)
                    return NotFound("Tema não encontrada no banco de dados.");

                return Ok(temas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Tema>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [Route("Temas")]
        public ActionResult PegarTemas()
        {
            try
            {
                List<Tema> temas = this._temaHandler.PegarTemas();

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
        [Route("Tema")]
        public ActionResult InsereTema([FromBody] Tema tema)
        {
            try
            {
                string resultado = this._temaHandler.InsereTema(tema);
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
        [Route("Tema")]
        public ActionResult AlteraTema([FromBody] Tema tema)
        {
            try
            {
                string resultado = this._temaHandler.AlteraTema(tema);
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
        [Route("Tema")]
        public ActionResult DeletaTema([FromBody] int idTema)
        {
            try
            {
                string resultado = this._temaHandler.DeletaTema(idTema);
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
        [Route("Experiencia")]
        public ActionResult PegarExperiencia()
        {
            try
            {
                return Ok(new List<Experiencia>()
            {
                new Experiencia()
            {
                Valor = 100,
                Nivel = 2
            },
                new Experiencia()
            {
                Valor = 200,
                Nivel = 3
            },
                new Experiencia()
            {
                Valor = 300,
                Nivel = 4
            },
            });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [Route("Experiencia")]
        public ActionResult InsereExperiencia([FromBody] Experiencia experiencia)
        {
            try
            {
                return Ok("Experiencia inserida com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [Route("Experiencia")]
        public ActionResult AlteraExperiencia([FromBody] Experiencia experiencia)
        {
            try
            {
                return Ok("Experiencia atualizada com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [Route("Experiencia")]
        public ActionResult DeletaExperiencia([FromBody] Experiencia experiencia)
        {
            try
            {
                return Ok("Experiencia deletada com sucesso.");
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
        [Route("SkinsPorDescricao")]
        public ActionResult PegarSkinsPorDescricao([FromQuery] string descricao)
        {

            try
            {
                return Ok(new List<Skin>()
            {
                new Skin()
            {
                Id = 1,
                Descricao = "Mock 1",
                Nivel = 1
            },
                new Skin()
            {
                Id = 2,
                Descricao = "Mock 2",
                Nivel = 2
            }
            });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Skin>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [Route("SkinsPorNivel")]
        public ActionResult PegarSkinsPorNivel([FromQuery] int nivel)
        {
            try
            {

                return Ok(new List<Skin>()
            {
                new Skin()
            {
                Id = 1,
                Descricao = "Mock 1",
                Nivel = 1
            },
                new Skin()
            {
                Id = 2,
                Descricao = "Mock 2",
                Nivel = 2
            }
            });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Skin))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [Route("SkinPorId")]
        public ActionResult PegarPalavras([FromQuery] int id)
        {
            try
            {

                return Ok(new Skin()
                {
                    Id = 2,
                    Descricao = "Mock 2",
                    Nivel = 2
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Skin>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [Route("Skins")]
        public ActionResult PegarSkins()
        {
            try
            {

                return Ok(new List<Skin>()
            {
                new Skin()
            {
                Id = 1,
                Descricao = "Mock 1",
                Nivel = 1
            },
                new Skin()
            {
                Id = 2,
                Descricao = "Mock 2",
                Nivel = 2
            }
            });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [Route("Skin")]
        public ActionResult InsereSkin([FromBody] Skin skin)
        {
            try
            {
                return Ok("Skin inserida com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [Route("Skin")]
        public ActionResult AlteraSkin([FromBody] Skin skin)
        {
            try
            {
                return Ok("Skin atualizada com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [Route("Skin")]
        public ActionResult DeletaSkin([FromBody] Skin skin)
        {
            try
            {
                return Ok("Skin deletada com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu uma falha na sua solicitação: {ex.Message}");
            }
        }
        #endregion
    }
}
