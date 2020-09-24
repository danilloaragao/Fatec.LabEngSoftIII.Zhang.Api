using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
using System.Collections.Generic;
using System.Linq;

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
            Tema temaBd = this._context.Temas.FirstOrDefault(t => t.Descricao.ToUpper().Equals(tema.ToUpper()));

            if (temaBd == null)
                return null;

            return this._context.Palavras.Where(p => p.IdTema == temaBd.Id).ToList();
        }

        public PalavraJogo PegarPalavra(int id)
        {
            return this._context.Palavras.FirstOrDefault(p => p.Id == id);
        }

        public List<PalavraJogo> PegarPalavrasPorTrecho(string palavra)
        {
            return this._context.Palavras.Where(p => p.Palavra.ToUpper().Contains(palavra.ToUpper())).ToList();
        }

        public List<PalavraJogo> PegarTodasPalavras()
        {
            return this._context.Palavras.ToList();
        }

        public string InserePalavra(PalavraJogo palavra)
        {
            try
            {
                this._context.Palavras.Add(palavra);
                this._context.SaveChanges();
                return "Palavra cadastrada com sucesso";
            }
            catch
            {
                return "Ocorreu uma falha ao cadastrar a palavra solicitada";
            }
        }

        public string AlteraPalavra(PalavraJogo palavra)
        {
            try
            {
                PalavraJogo palavraJogo = this._context.Palavras.FirstOrDefault(p => p.Id == palavra.Id);
                if (palavraJogo == null)
                    return "Id da palavra não encontrado no banco de dados";

                if (this._context.Temas.Count(t => t.Id == palavra.IdTema) == 0)
                    return "Id do tema não encontrado no banco de dados";

                palavraJogo.Palavra = palavra.Palavra;
                palavraJogo.IdTema = palavra.IdTema;
                palavraJogo.Dica1 = palavra.Dica1;
                palavraJogo.Dica2 = palavra.Dica2;
                this._context.SaveChanges();

                return "Palavra atualizada com sucesso";

            }
            catch
            {
                return "Ocorreu uma falha ao alterar a palavra solicitada";
            }
        }

        public string DeletaPalavra(int idPalavra)
        {
            try
            {
                PalavraJogo palavraJogo = this._context.Palavras.FirstOrDefault(p => p.Id == idPalavra);
                if (palavraJogo == null)
                    return "Id da palavra não encontrado no banco de dados";

                this._context.Palavras.Remove(palavraJogo);
                this._context.SaveChanges();
                return "Palava deletada com sucesso.";
            }
            catch
            {
                return "Ocorreu uma falha ao deletar a palavra solicitada";
            }
        }
    }
}
