using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades.Entradas;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades.Saidas;
using Fatec.LabEngSoftIII.Zhang.API.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Fatec.LabEngSoftIII.Zhang.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministracaoController : ControllerBase
    {
        #region Palavras
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PalavraJogo>))]
        [Route("PalavrasPorTema")]
        public ActionResult PegarPalavrasPorTema([FromRoute] string tema)
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PalavraJogo))]
        [Route("PalavraPorId")]
        public ActionResult PegarPalvra([FromRoute] int id)
        {

            return Ok(new PalavraJogo()
            {
                Id = 1,
                Palavra = "Mock",
                Dica1 = "Dica 1",
                Dica2 = "Dica 2"
            });
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PalavraJogo>))]
        [Route("PalavrasPorTrecho")]
        public ActionResult PegarPalavrasPorTreco([FromRoute] string palavra)
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PalavraJogo>))]
        [Route("Palavras")]
        public ActionResult PegarTodasPalavras()
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [Route("Palavra")]
        public ActionResult InserePalavra([FromBody] PalavraJogo palavra)
        {
            return Ok("Palava inserida com sucesso.");
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [Route("Palavra")]
        public ActionResult AlteraPalavra([FromBody] PalavraJogo palavra)
        {
            return Ok("Palava atualizada com sucesso.");
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [Route("Palavra")]
        public ActionResult DeletaPalavra([FromBody] int idPalavra)
        {
            return Ok("Palava deletada com sucesso.");
        }
        #endregion

        #region Temas
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Tema))]
        [Route("TemaPorId")]
        public ActionResult PegarTema([FromRoute] int id)
        {

            return Ok(new Tema()
            {
                Id = 1,
                Descricao = "Mock"
            });
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Tema>))]
        [Route("TemasPorDescricao")]
        public ActionResult PegarTemasPorDescricao([FromRoute] string tema)
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Tema>))]
        [Route("Temas")]
        public ActionResult PegarTemas()
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [Route("Tema")]
        public ActionResult InsereTema([FromBody] Tema tema)
        {
            return Ok("Tema inserido com sucesso.");
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [Route("Tema")]
        public ActionResult AlteraPalavra([FromBody] Tema tema)
        {
            return Ok("Tema atualizado com sucesso.");
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [Route("Tema")]
        public ActionResult DeletaTema([FromBody] int idTema)
        {
            return Ok("Tema deletado com sucesso.");
        }
        #endregion

        #region Experiencia
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Experiencia>))]
        [Route("Experiencia")]
        public ActionResult PegarExperiencia()
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [Route("Experiencia")]
        public ActionResult InsereExperiencia([FromBody] Experiencia experiencia)
        {
            return Ok("Experiencia inserida com sucesso.");
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [Route("Experiencia")]
        public ActionResult AlteraExperiencia([FromBody] Experiencia experiencia)
        {
            return Ok("Experiencia atualizada com sucesso.");
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [Route("Experiencia")]
        public ActionResult DeletaExperiencia([FromBody] Experiencia experiencia)
        {
            return Ok("Experiencia deletada com sucesso.");
        }
        #endregion

        #region Skins
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Skin>))]
        [Route("SkinsPorDescricao")]
        public ActionResult PegarSkinsPorDescricao([FromRoute] string descricao)
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Skin>))]
        [Route("SkinsPorNivel")]
        public ActionResult PegarSkinsPorNivel([FromRoute] int nivel)
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Skin))]
        [Route("SkinPorId")]
        public ActionResult PegarPalavras([FromRoute] int id)
        {

            return Ok(new Skin()
            {
                Id = 2,
                Descricao = "Mock 2",
                Nivel = 2
            });
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Skin>))]
        [Route("Skins")]
        public ActionResult PegarSkins()
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [Route("Skin")]
        public ActionResult InsereSkin([FromBody] Skin skin)
        {
            return Ok("Skin inserida com sucesso.");
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [Route("Skin")]
        public ActionResult AlteraSkin([FromBody] Skin skin)
        {
            return Ok("Skin atualizada com sucesso.");
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [Route("Skin")]
        public ActionResult DeletaSkin([FromBody] Skin skin)
        {
            return Ok("Skin deletada com sucesso.");
        }
        #endregion
    }
}
