using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fatec.LabEngSoftIII.Zhang.Api.Database
{
    public class PalavraBD
    {
        private Context _context { get; set; }

        public PalavraBD()
        {
            this._context = new Context();
        }


        public List<PalavraJogo> PegarPalavrasPorTema(string tema)
        {
            return null;
        }

        public PalavraJogo PegarPalvra(int id)
        {

            return null;
        }

        public List<PalavraJogo> PegarPalavrasPorTreco(string palavra)
        {

            return null;
        }

        public List<PalavraJogo> PegarTodasPalavras()
        {

            return null;
        }

        public string InserePalavra(PalavraJogo palavra)
        {
            return "Palava inserida com sucesso.";
        }

        public string AlteraPalavra(PalavraJogo palavra)
        {
            return "Palava atualizada com sucesso.";
        }

        public string DeletaPalavra(int idPalavra)
        {
            return "Palava deletada com sucesso.";
        }
    }
}
