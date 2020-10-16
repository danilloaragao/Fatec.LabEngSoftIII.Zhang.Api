using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Fatec.LabEngSoftIII.Zhang.Api.Database
{
    public class PalavraBD
    {
        private Context Context { get; set; }

        public PalavraBD()
        {
            this.Context = new Context();
        }


        public List<PalavraJogo> PegarPalavrasPorTema(string tema)
        {
            Tema temaBd = this.Context.Temas.FirstOrDefault(t => t.Descricao.ToUpper().Equals(tema.ToUpper()));

            if (temaBd == null)
                return null;

            return this.Context.Palavras.Where(p => p.IdTema == temaBd.Id).OrderBy(p => p.Id).ToList();
        }

        public PalavraJogo PegarPalavra(int id)
        {
            return this.Context.Palavras.FirstOrDefault(p => p.Id == id);
        }

        public List<PalavraJogo> PegarPalavrasPorTrecho(string palavra)
        {
            return this.Context.Palavras.Where(p => p.Palavra.ToUpper().Contains(palavra.ToUpper())).OrderBy(p => p.Id).ToList();
        }

        public List<PalavraJogo> PegarTodasPalavras()
        {
            return this.Context.Palavras.OrderBy(p => p.Id).ToList();
        }

        public string InserePalavra(PalavraJogo palavra)
        {
            this.Context.Palavras.Add(palavra);
            this.Context.SaveChanges();
            return "Palavra cadastrada com sucesso";
        }

        public string AlteraPalavra(PalavraJogo palavra)
        {
            PalavraJogo palavraJogo = this.Context.Palavras.FirstOrDefault(p => p.Id == palavra.Id);

            palavraJogo.Palavra = palavra.Palavra;
            palavraJogo.IdTema = palavra.IdTema;
            palavraJogo.Dica1 = palavra.Dica1;
            palavraJogo.Dica2 = palavra.Dica2;
            this.Context.SaveChanges();

            return "Palavra atualizada com sucesso";
        }

        public string DeletaPalavra(int idPalavra)
        {
            PalavraJogo palavraJogo = this.Context.Palavras.FirstOrDefault(p => p.Id == idPalavra);

            this.Context.Palavras.Remove(palavraJogo);
            this.Context.SaveChanges();
            return "Palavra deletada com sucesso.";
        }
        public string DeletaPalavraPorTema(int idTema)
        {
            List<PalavraJogo> palavras = this.Context.Palavras.Where(p => p.IdTema == idTema).ToList();

            this.Context.Palavras.RemoveRange(palavras);
            this.Context.SaveChanges();
            return "Palavra deletada com sucesso.";
        }
    }
}
