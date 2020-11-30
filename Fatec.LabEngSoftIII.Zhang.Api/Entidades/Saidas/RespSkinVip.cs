namespace Fatec.LabEngSoftIII.Zhang.Api.Entidades.Saidas
{
    public class RespSkinVip
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public byte[] Sprite { get; set; }
        public byte[] JumpScare { get; set; }
        public int Nivel { get; set; }
        public bool Comprada { get; set; }
    }
}
