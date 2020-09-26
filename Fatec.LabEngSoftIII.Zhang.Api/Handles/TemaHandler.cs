using Fatec.LabEngSoftIII.Zhang.Api.Database;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Fatec.LabEngSoftIII.Zhang.Api.Handles
{
    public class TemaHandler
    {
        readonly private TemaBD TemaBD = new TemaBD();

        public Tema PegarTema(int? id)
        {
            if (id == null)
                return null;

            return this.TemaBD.PegarTema(id ?? 0);
        }

        public List<Tema> PegarTemasPorDescricao(string tema)
        {
            if (string.IsNullOrWhiteSpace(tema))
                return null;

            return this.TemaBD.PegarTemasPorDescricao(tema);
        }

        public List<Tema> PegarTemas()
        {
            return this.TemaBD.PegarTemas();
        }

        public string InsereTema(Tema tema)
        {
            if (tema == null)
                return "Falha ao receber as informações do tema";

            if (string.IsNullOrWhiteSpace(tema.Descricao))
                return "A descrição não pode estar em branco";

            List<Tema> temas = PegarTemasPorDescricao(tema.Descricao);

            if (temas.Any(t => t.Descricao.ToUpper().Equals(tema.Descricao.ToUpper())))
                return "Tema já existe no banco de dados";

            return this.TemaBD.InsereTema(tema);
        }

        public string AlteraTema(Tema tema)
        {
            if (tema == null)
                return "Falha ao receber as informações do tema";

            Tema temaBd = PegarTema(tema.Id);

            if (temaBd == null)
                return "Id não encontrado no banco de dados";

            if (string.IsNullOrWhiteSpace(tema.Descricao))
                return "A descrição não pode estar em branco";

            return this.TemaBD.AlteraPalavra(tema);
        }

        public string DeletaTema(int? idTema)
        {
            if (idTema == null)
                return null;

            Tema temaBd = PegarTema(idTema ?? 0);

            if (temaBd == null)
                return "Id não encontrado no banco de dados";

            return this.TemaBD.DeletaTema(idTema ?? 0);
        }
    }
}
