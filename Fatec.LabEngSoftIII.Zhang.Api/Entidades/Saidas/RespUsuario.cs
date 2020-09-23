using System.Collections.Generic;

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

    }
}
