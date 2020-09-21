using Fatec.LabEngSoftIII.Zhang.Api.Entidades.Entradas;

namespace Fatec.LabEngSoftIII.Zhang.Api.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public int Experiencia { get; set; }
    }
}
