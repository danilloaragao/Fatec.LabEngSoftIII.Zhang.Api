using Fatec.LabEngSoftIII.Zhang.Api.Database;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades.Entradas;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades.Saidas;
using Fatec.LabEngSoftIII.Zhang.Api.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Fatec.LabEngSoftIII.Zhang.Api.Handles
{
    public class JogoHandler
    {
        private readonly JogoBD JogoBD = new JogoBD();
        private readonly UsuarioBD UsuarioBD = new UsuarioBD();
        private readonly UsuarioHandler UsuarioHandler = new UsuarioHandler();

        public string AlteracaoSkins(List<ReqSkin> skins, int idUsuario)
        {
            JogoBD.AlteracaoSkins(skins, idUsuario);
            return "Alterações realizadas com sucesso";
        }

        public RespUsuario AcertoPalavra(ReqAcerto acerto, int idUsuario)
        {
            if (string.IsNullOrWhiteSpace(acerto.Palavra))
                return null;

            int qtdLetras = acerto.Palavra.ToUpper().Distinct().Count();

            int experienciaGanha = (qtdLetras * 5) - (acerto.Erros * 2) - (acerto.DicasUsadas * 3);

            int nivelAntigoUsuario = UsuarioHandler.MontarRespUsuario(UsuarioBD.PegarUsuarioPeloId(idUsuario)).Nivel;

            JogoBD.AcertoPalavra(experienciaGanha, idUsuario);

            RespUsuario usuario = UsuarioHandler.MontarRespUsuario(UsuarioBD.PegarUsuarioPeloId(idUsuario));

            if (usuario.Nivel == nivelAntigoUsuario)
                return usuario;

            JogoBD.AtualizarSkins(usuario);

            return UsuarioHandler.MontarRespUsuario(UsuarioBD.PegarUsuarioPeloId(idUsuario));
        }

        public RespUsuario CompraSkin(int idSkin, int idUsuario)
        {
            Skin skin = JogoBD.PegarSkinVipPeloId(idSkin);
            if (skin == null)
                return null;

            Usuario usuario = UsuarioBD.PegarUsuarioPeloId(idUsuario);
            if (usuario == null)
                return null;

            if (JogoBD.ExisteUsuarioSkin(idSkin, idUsuario))
                throw new SkinObtidaException();

            if (skin.ValorCash > usuario.Cash)
                throw new CashInsuficienteException();

            JogoBD.ComprarSkin(idSkin, idUsuario);

            return UsuarioHandler.MontarRespUsuario(UsuarioBD.PegarUsuarioPeloId(idUsuario));
        }

        public List<RespRanking> Ranking(int idUsuario)
        {
            List<RespRanking> rankings = new List<RespRanking>();
            List<Experiencia> experiencia = JogoBD.PegarExperiencias();

            List<Usuario> usuariosTop = JogoBD.TopCinco();

            foreach (Usuario usuario in usuariosTop)
            {
                RespRanking ranking = new RespRanking();

                List<Experiencia> niveisAbaixo = experiencia.Where(e => e.Valor < usuario.Experiencia).ToList();

                if (niveisAbaixo == null || niveisAbaixo.Count == 0)
                    ranking.Nivel = 0;
                else
                    ranking.Nivel = niveisAbaixo.Max(e => e.Nivel);

                ranking.Login = usuario.Login;
                ranking.Posicao = usuariosTop.IndexOf(usuario) + 1;
                ranking.Experiencia = usuario.Experiencia;

                rankings.Add(ranking);
            }

            if (!usuariosTop.Any(u => u.Id == idUsuario))
            {
                Usuario usuario = UsuarioBD.PegarUsuarioPeloId(idUsuario);

                RespRanking ranking = new RespRanking();

                List<Experiencia> niveisAbaixo = experiencia.Where(e => e.Valor < usuario.Experiencia).ToList();

                if (niveisAbaixo == null || niveisAbaixo.Count == 0)
                    ranking.Nivel = 0;
                else
                    ranking.Nivel = niveisAbaixo.Max(e => e.Nivel);

                ranking.Login = usuario.Login;
                ranking.Experiencia = usuario.Experiencia;
                ranking.Posicao = JogoBD.PegarColocacaoPelaExperiencia(usuario.Experiencia);

                rankings.Add(ranking);
            }

            return rankings;
        }

        public void CompraCash(int qtdCash, int idUsuario)
        {
            UsuarioBD.CompraCash(qtdCash, idUsuario);
        }
    }
}
