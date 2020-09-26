using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Fatec.LabEngSoftIII.Zhang.Api.Database
{
    public class TemaBD
    {
        readonly private Context Context = new Context();
        public Tema PegarTema(int id)
        {
            return this.Context.Temas.Where(t => t.Id == id).FirstOrDefault();
        }

        public List<Tema> PegarTemasPorDescricao(string tema)
        {
            return this.Context.Temas.Where(p => p.Descricao.ToUpper().Contains(tema.ToUpper())).OrderBy(p => p.Id).ToList();
        }

        public List<Tema> PegarTemas()
        {
            return this.Context.Temas.OrderBy(p => p.Id).ToList();
        }

        public string InsereTema(Tema tema)
        {
            this.Context.Temas.Add(tema);
            this.Context.SaveChanges();
            return "Tema cadastrado com sucesso";
        }

        public string AlteraPalavra(Tema tema)
        {
            Tema temaBd = this.Context.Temas.FirstOrDefault(t => t.Id == tema.Id);

            temaBd.Descricao = tema.Descricao;
            this.Context.SaveChanges();

            return "Tema atualizado com sucesso";
        }

        public string DeletaTema(int idTema)
        {
            Tema temaBd = this.Context.Temas.FirstOrDefault(t => t.Id == idTema);

            this.Context.Temas.Remove(temaBd);
            this.Context.SaveChanges();
            return "Tema deletado com sucesso.";
        }
    }
}
