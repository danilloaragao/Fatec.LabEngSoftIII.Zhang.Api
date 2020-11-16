using Fatec.LabEngSoftIII.Zhang.Api.Database;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Fatec.LabEngSoftIII.Zhang.Api.Handles
{
    public class PalavraHandler
    {
        readonly private PalavraBD PalavraBD = new PalavraBD();

        public PalavraJogo PegarPalavra(int? id)
        {
            if (id == null)
                return null;

            return this.PalavraBD.PegarPalavra(id ?? 0);
        }

        public List<PalavraJogo> PegarPalavrasPorTrecho(string palavra)
        {
            if (string.IsNullOrWhiteSpace(palavra))
                return null;

            return this.PalavraBD.PegarPalavrasPorTrecho(palavra);
        }

        public List<PalavraJogo> PegarTodasPalavras()
        {
            return this.PalavraBD.PegarTodasPalavras();
        }

        public string InserePalavra(PalavraJogo palavra)
        {
            if (palavra == null)
                return "Falha ao receber as informações da palavra";

            List<string> incosistencias = new List<string>();

            if (string.IsNullOrWhiteSpace(palavra.Palavra))
                incosistencias.Add("A palavra não pode estar em branco");
            else
            {
                List<PalavraJogo> palavras = PegarPalavrasPorTrecho(palavra.Palavra);

                if (palavras.Any(p => p.Palavra.ToUpper().Equals(palavra.Palavra.ToUpper())))
                    return "Palavra já existe no banco de dados";
            }

            TemaHandler temaHandler = new TemaHandler();
            Tema tema = temaHandler.PegarTema(palavra.IdTema);

            if (tema == null)
                incosistencias.Add("Id do tema não encontrado no banco de dados");

            if (string.IsNullOrWhiteSpace(palavra.Dica1))
                incosistencias.Add("A primeira dica não pode estar em branco");

            if (string.IsNullOrWhiteSpace(palavra.Dica2))
                incosistencias.Add("A segunda dica não pode estar em branco");

            if (incosistencias.Count > 0)
                return string.Join(" - ", incosistencias);

            return this.PalavraBD.InserePalavra(palavra);
        }

        public string AlteraPalavra(PalavraJogo palavra)
        {
            if (palavra == null)
                return "Falha ao receber as informações da palavra";

            List<string> incosistencias = new List<string>();

            PalavraJogo palavraBd = PegarPalavra(palavra.Id);

            if (palavraBd == null)
                return "Id não encontrado no banco de dados";


            if (string.IsNullOrWhiteSpace(palavra.Palavra))
                incosistencias.Add("A palavra não pode estar em branco");
           

            TemaHandler temaHandler = new TemaHandler();
            Tema tema = temaHandler.PegarTema(palavra.IdTema);

            if (tema == null)
                incosistencias.Add("Id do tema não encontrado no banco de dados");

            if (string.IsNullOrWhiteSpace(palavra.Dica1))
                incosistencias.Add("A primeira dica não pode estar em branco");

            if (string.IsNullOrWhiteSpace(palavra.Dica2))
                incosistencias.Add("A segunda dica não pode estar em branco");

            if (incosistencias.Count > 0)
                return string.Join(" - ", incosistencias);

            return this.PalavraBD.AlteraPalavra(palavra);
        }

        public string DeletaPalavra(int? idPalavra)
        {
            if (idPalavra == null)
                return "Falha ao receber id da palavra";

            PalavraJogo palavraBd = PegarPalavra(idPalavra ?? 0);

            if (palavraBd == null)
                return "Id não encontrado no banco de dados";

            return this.PalavraBD.DeletaPalavra(idPalavra ?? 0);
        }
    }
}
