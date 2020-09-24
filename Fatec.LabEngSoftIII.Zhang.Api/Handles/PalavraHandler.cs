using Fatec.LabEngSoftIII.Zhang.Api.Database;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fatec.LabEngSoftIII.Zhang.Api.Handles
{
    public class PalavraHandler
    {
        private PalavraBD _palavraBD = new PalavraBD();
        public List<PalavraJogo> PegarPalavrasPorTema(string tema)
        {
            if(string.IsNullOrWhiteSpace(tema))
                return null;

            return this._palavraBD.PegarPalavrasPorTema(tema);
        }

        public PalavraJogo PegarPalavra(int id)
        {
            return this._palavraBD.PegarPalavra(id);
        }

        public List<PalavraJogo> PegarPalavrasPorTrecho(string palavra)
        {
            if (string.IsNullOrWhiteSpace(palavra))
                return null;

            return this._palavraBD.PegarPalavrasPorTrecho(palavra);
        }

        public List<PalavraJogo> PegarTodasPalavras()
        {
            return this._palavraBD.PegarTodasPalavras();
        }

        public string InserePalavra(PalavraJogo palavra)
        {
            List<PalavraJogo> palavras = PegarPalavrasPorTrecho(palavra.Palavra);

            return null;// this._palavraBD.PegarPalavrasPorTema(palavra);
        }

        public string AlteraPalavra(PalavraJogo palavra)
        {
            return null;
        }

        public string DeletaPalavra(int idPalavra)
        {
            return null;
        }
    }
}
