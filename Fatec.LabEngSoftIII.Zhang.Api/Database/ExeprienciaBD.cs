using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Fatec.LabEngSoftIII.Zhang.Api.Database
{
    public class ExeprienciaBD
    {
        readonly private Context context = new Context();

        public List<Experiencia> PegarExperiencias()
        {
            return this.context.Experiencia.OrderBy(e => e.Nivel).ToList();
        }

        public string InsereExperiencia(Experiencia Experiencia)
        {
            this.context.Experiencia.Add(Experiencia);
            this.context.SaveChanges();
            return "Experiencia cadastrada com sucesso";
        }

        public string AlteraExperiencia(Experiencia Experiencia)
        {
            Experiencia ExperienciaBd = this.context.Experiencia.FirstOrDefault(t => t.Id == Experiencia.Id);

            ExperienciaBd.Nivel = Experiencia.Nivel;
            ExperienciaBd.Valor = Experiencia.Valor;
            this.context.SaveChanges();

            return "Experiencia atualizada com sucesso";
        }

        public string DeletaExperiencia(int idExperiencia)
        {
            Experiencia ExperienciaBd = this.context.Experiencia.FirstOrDefault(t => t.Id == idExperiencia);

            this.context.Experiencia.Remove(ExperienciaBd);
            this.context.SaveChanges();
            return "Experiencia deletada com sucesso.";
        }
    }
}
