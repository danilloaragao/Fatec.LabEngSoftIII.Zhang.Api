namespace Fatec.LabEngSoftIII.Zhang.Api.Entidades.Saidas
{
    public class RespSkin
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public byte[] Sprite { get; set; }
        public byte[] JumpScare { get; set; }
        public int Nivel { get; set; }
        public bool Ativo { get; set; }
    }
}
