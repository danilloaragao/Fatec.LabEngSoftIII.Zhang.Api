using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Fatec.LabEngSoftIII.Zhang.Api.Database
{
    public class TemaBD
    {
        Context _context = new Context();
        public Tema PegarTema(int id)
        {
            return this._context.Temas.Where(t => t.Id == id).FirstOrDefault();
        }

        public List<Tema> PegarTemasPorDescricao(string tema)
        {
            return this._context.Temas.Where(p => p.Descricao.ToUpper().Contains(tema.ToUpper())).ToList();
        }

        public List<Tema> PegarTemas()
        {
            return this._context.Temas.ToList();
        }

        public string InsereTema(Tema tema)
        {
            this._context.Temas.Add(tema);
            this._context.SaveChanges();
            return "Tema cadastrado com sucesso";
        }

        public string AlteraPalavra(Tema tema)
        {
            Tema temaBd = this._context.Temas.FirstOrDefault(t => t.Id == tema.Id);

            temaBd.Descricao = tema.Descricao;
            this._context.SaveChanges();

            return "Tema atualizado com sucesso";
        }

        public string DeletaTema(int idTema)
        {
            Tema temaBd = this._context.Temas.FirstOrDefault(t => t.Id == idTema);

            this._context.Temas.Remove(temaBd);
            this._context.SaveChanges();
            return "Tema deletado com sucesso.";
        }
    }
}
