using Fatec.LabEngSoftIII.Zhang.Api.Database;
using System.Collections.Generic;
using System.Linq;
using Fatec.LabEngSoftIII.Zhang.API.Utils;

namespace Fatec.LabEngSoftIII.Zhang.Api.Entidades.Saidas
{
    public class RespUsuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public int Experiencia { get; set; }
        public int ExperienciaProximoNivel { get; set; }
        public int Nivel { get; set; }
        public List<RespSkin> Skins { get; set; }
        public string Token { get; set; }
        public int Cash { get; set; }

        public static RespUsuario MontarRespUsuario(Usuario usuarioBD)
        {
            JogoBD JogoBD = new JogoBD();
            Token Token = new Token();

            RespUsuario usuario = new RespUsuario
            {
                Id = usuarioBD.Id,
                Login = usuarioBD.Login,
                Email = usuarioBD.Email,
                Experiencia = usuarioBD.Experiencia,
                Cash = usuarioBD.Cash
            };

            List<Experiencia> experiencia = JogoBD.PegarExperiencias();

            List<Experiencia> niveisAbaixo = experiencia.Where(e => e.Valor < usuario.Experiencia).ToList();

            if (niveisAbaixo == null || niveisAbaixo.Count == 0)
                usuario.Nivel = 0;
            else
                usuario.Nivel = niveisAbaixo.Max(e => e.Nivel);

            List<Experiencia> niveisAcima = experiencia.Where(e => e.Valor > usuario.Experiencia).ToList();

            if (niveisAcima == null || niveisAcima.Count == 0)
                usuario.ExperienciaProximoNivel = 0;
            else
                usuario.ExperienciaProximoNivel = niveisAcima.Min(e => e.Valor) - usuario.Experiencia;

            usuario.Skins = JogoBD.PegarSkinAtiva(usuario.Id);
            usuario.Token = Token.Gerar(usuario.Login, usuario.Id, usuarioBD.IsAdmin);

            return usuario;
        }
    }
}
