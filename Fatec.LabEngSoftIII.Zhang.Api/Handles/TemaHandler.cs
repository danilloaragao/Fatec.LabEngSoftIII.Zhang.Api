using Fatec.LabEngSoftIII.Zhang.Api.Database;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Fatec.LabEngSoftIII.Zhang.Api.Handles
{
    public class TemaHandler
    {
        private TemaBD _temaBD = new TemaBD();

        public Tema PegarTema(int id)
        {
            return this._temaBD.PegarTema(id);
        }

        public List<Tema> PegarTemasPorDescricao(string tema)
        {
            if (string.IsNullOrWhiteSpace(tema))
                return null;

            return this._temaBD.PegarTemasPorDescricao(tema);
        }

        public List<Tema> PegarTemas()
        {
            return this._temaBD.PegarTemas();
        }

        public string InsereTema(Tema tema)
        {
            if (string.IsNullOrWhiteSpace(tema.Descricao))
                return "A descrição não pode estar em branco";

            List<Tema> temas = PegarTemasPorDescricao(tema.Descricao);

            if (temas.Any(t => t.Descricao.ToUpper().Equals(tema.Descricao.ToUpper())))
                return "Tema já existe no banco de dados";

            return this._temaBD.InsereTema(tema);
        }

        public string AlteraTema(Tema tema)
        {
            Tema temaBd = PegarTema(tema.Id);

            if (temaBd == null)
                return "Id não existe no banco de dados";

            if (string.IsNullOrWhiteSpace(tema.Descricao))
                return "A descrição não pode estar em branco";

            return this._temaBD.AlteraPalavra(tema);
        }

        public string DeletaTema(int idTema)
        {
            Tema temaBd = PegarTema(idTema);

            if (temaBd == null)
                return "Id não existe no banco de dados";

            return this._temaBD.DeletaTema(idTema);
        }
    }
}
