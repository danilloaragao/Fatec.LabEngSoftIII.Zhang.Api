using Fatec.LabEngSoftIII.Zhang.Api.Database;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Fatec.LabEngSoftIII.Zhang.Api.Handles
{
    public class ExperienciaHandler
    {
        readonly private ExeprienciaBD ExperienciaBD = new ExeprienciaBD();

        public List<Experiencia> PegarExperiencias()
        {
            return this.ExperienciaBD.PegarExperiencias();
        }

        public string InsereExperiencia(Experiencia experiencia)
        {
            if (experiencia == null)
                return "Falha ao receber as informações da experiencia";

            if (experiencia.Nivel == 0)
                return "O nível não pode ser zero";

            if (experiencia.Valor == 0)
                return "A experiência não pode ser zero";

            List<Experiencia> experienciasBd = PegarExperiencias();

            if (experienciasBd.Any(e => e.Nivel == experiencia.Nivel))
                return "Nível já inserido no banco de dados";

            if (experienciasBd.Any(e => e.Valor == experiencia.Valor))
                return "Valor de experiencia já atribuído a um nível";

            List<Experiencia> experienciasNivelAcima = experienciasBd.Where(e => e.Nivel > experiencia.Nivel).OrderBy(e => e.Nivel).ToList();
            List<Experiencia> experienciasNivelAbaixo = experienciasBd.Where(e => e.Nivel < experiencia.Nivel).OrderByDescending(e => e.Nivel).ToList();

            if (experienciasNivelAcima != null && experienciasNivelAcima.Count > 0 && experienciasNivelAcima.FirstOrDefault().Valor < experiencia.Valor)
                return "O valor da experiência de um nível não pode ser maior que a experiência de níveis acima";
            if (experienciasNivelAbaixo != null && experienciasNivelAbaixo.Count > 0 && experienciasNivelAbaixo.FirstOrDefault().Valor > experiencia.Valor)
                return "O valor da experiência de um nível não pode ser menor que a experiência de níveis abaixo";

            return this.ExperienciaBD.InsereExperiencia(experiencia);
        }

        public string AlteraExperiencia(Experiencia experiencia)
        {
            if (experiencia == null)
                return "Falha ao receber as informações da experiencia";

            if (experiencia.Nivel == 0)
                return "O nível não pode ser zero";

            if (experiencia.Valor == 0)
                return "A experiência não pode ser zero";

            List<Experiencia> experienciasBd = PegarExperiencias();

            if (!experienciasBd.Any(e => e.Id == experiencia.Id))
                return "Id não encontrado no banco de dados";

            if (experienciasBd.Any(e => e.Nivel == experiencia.Nivel && e.Id != experiencia.Id))
                return "Nível já inserido no banco de dados";

            if (experienciasBd.Any(e => e.Valor == experiencia.Valor && e.Id != experiencia.Id))
                return "Valor de experiencia já atribuído a um nível";

            List<Experiencia> experienciasNivelAcima = experienciasBd.Where(e => e.Nivel > experiencia.Nivel).ToList();
            List<Experiencia> experienciasNivelAbaixo = experienciasBd.Where(e => e.Nivel < experiencia.Nivel).ToList();

            if (experienciasNivelAcima != null && experienciasNivelAcima.Count > 0 && experienciasNivelAcima.Min().Valor < experiencia.Valor)
                return "O valor da experiência de um nível não pode ser maior que a experiência de níveis acima";

            if (experienciasNivelAbaixo != null && experienciasNivelAbaixo.Count > 0 && experienciasNivelAbaixo.Max().Valor > experiencia.Valor)
                return "O valor da experiência de um nível não pode ser menor que a experiência de níveis abaixo";

            return this.ExperienciaBD.AlteraExperiencia(experiencia);
        }

        public string DeletaExperiencia(int? idExperiencia)
        {
            if (idExperiencia == null)
                return null;

            if (!PegarExperiencias().Any(e => e.Id == idExperiencia))
                return "Id não encontrado no banco de dados";

            return this.ExperienciaBD.DeletaExperiencia(idExperiencia ?? 0);
        }
    }
}
