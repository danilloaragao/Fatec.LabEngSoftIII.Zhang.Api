using Fatec.LabEngSoftIII.Zhang.Api.Database;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades.Entradas;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades.Saidas;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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
    }
}
