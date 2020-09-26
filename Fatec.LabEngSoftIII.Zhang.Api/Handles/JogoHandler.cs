using Fatec.LabEngSoftIII.Zhang.Api.Database;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades.Entradas;
using System.Collections.Generic;

namespace Fatec.LabEngSoftIII.Zhang.Api.Handles
{
    public class JogoHandler
    {
        private readonly JogoBD JogoBD = new JogoBD();

        public string AlteracaoSkins(List<ReqSkin> skins, int idUsuario)
        {
            JogoBD.AlteracaoSkins(skins, idUsuario);
            return "Alterações realizadas com sucesso";
        }
    }
}
