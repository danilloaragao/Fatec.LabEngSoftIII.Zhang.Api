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
        public ActionResult PegarPalavra([FromRoute] int id)
        {
            try
            {

                return Ok(new PalavraJogo()
                {
                    Id = 1,
                    Palavra = "Mock",
                    Dica1 = "Dica 1",
                    Dica2 = "Dica 2"
                });
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
        public ActionResult PegarPalavrasPorTrecho([FromRoute] string palavra)
        {
            try
            {

                return Ok(new List<PalavraJogo>(){ new PalavraJogo()
            {
                Id = 1,
                Palavra = "Mock",
                Dica1 = "Dica 1",
                Dica2 = "Dica 2"
            }
            });
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
                return Ok(new List<PalavraJogo>(){ new PalavraJogo()
            {
                Id = 1,
                Palavra = "Mock",
                Dica1 = "Dica 1",
                Dica2 = "Dica 2"
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
        [Route("Palavra")]
        public ActionResult InserePalavra([FromBody] PalavraJogo palavra)
        {
            try
            {
                return Ok("Palava inserida com sucesso.");
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
                return Ok("Palava atualizada com sucesso.");
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
                return Ok("Palava deletada com sucesso.");
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
        public ActionResult PegarTema([FromRoute] int id)
        {

            try
            {
                return Ok(new Tema()
                {
                    Id = 1,
                    Descricao = "Mock"
                });
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
        public ActionResult PegarTemasPorDescricao([FromRoute] string tema)
        {
            try
            {


                return Ok(new List<Tema>(){ new Tema()
            {
                Id = 1,
                Descricao = "Mock"
            },
             new Tema()
            {
                Id = 2,
                Descricao = "Mock 2"
            }
            });
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

                return Ok(new List<Tema>(){ new Tema()
            {
                Id = 1,
                Descricao = "Mock"
            },
             new Tema()
            {
                Id = 2,
                Descricao = "Mock 2"
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
        [Route("Tema")]
        public ActionResult InsereTema([FromBody] Tema tema)
        {
            try
            {
                return Ok("Tema inserido com sucesso.");
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
        public ActionResult AlteraPalavra([FromBody] Tema tema)
        {
            try
            {
                return Ok("Tema atualizado com sucesso.");
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
                return Ok("Tema deletado com sucesso.");
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
        public ActionResult PegarSkinsPorDescricao([FromRoute] string descricao)
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
        public ActionResult PegarSkinsPorNivel([FromRoute] int nivel)
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
        public ActionResult PegarPalavras([FromRoute] int id)
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
