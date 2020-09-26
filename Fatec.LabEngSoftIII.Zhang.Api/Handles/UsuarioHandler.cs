using Fatec.LabEngSoftIII.Zhang.Api.Database;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades.Entradas;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades.Saidas;
using Fatec.LabEngSoftIII.Zhang.API.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Fatec.LabEngSoftIII.Zhang.Api.Handles
{
    public class UsuarioHandler
    {
        private readonly UsuarioBD UsuarioBD = new UsuarioBD();
        private readonly JogoBD JogoBD = new JogoBD();
        private readonly Token Token = new Token();
        private readonly Criptografia Criptografia = new Criptografia();

        public RespUsuario Login(ReqCredenciais credenciais)
        {
            Usuario usuarioBD = UsuarioBD.PegarUsuarioPeloLogin(credenciais.Login);

            if (usuarioBD == null || !credenciais.Senha.Equals(Criptografia.Decriptografar(usuarioBD.Senha)))
                return null;

            RespUsuario usuario = new RespUsuario
            {
                Id = usuarioBD.Id,
                Login = usuarioBD.Login,
                Email = usuarioBD.Email,
                Experiencia = usuarioBD.Experiencia
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

            usuario.Skins = JogoBD.PegarSkinsUsuario(usuario.Id) ?? new List<RespSkin>();
            usuario.Token = Token.Gerar(usuario.Login, usuario.Id);

            return usuario;
        }
    }
}
