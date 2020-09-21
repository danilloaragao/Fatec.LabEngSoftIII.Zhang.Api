using System.Collections.Generic;

namespace Fatec.LabEngSoftIII.Zhang.Api.Entidades.Saidas
{
    public class RespPalavraJogo
    {
        public int Id { get; set; }
        public string Palavra { get; set; }
        public string Dica1 { get; set; }
        public string Dica2 { get; set; }
        public List<string> Letras { get; set; }
    }
}
