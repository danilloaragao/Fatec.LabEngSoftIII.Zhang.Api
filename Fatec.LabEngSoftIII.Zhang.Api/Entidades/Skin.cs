namespace Fatec.LabEngSoftIII.Zhang.Api.Entidades
{
    public class Skin
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public byte[] BracoDireito { get; set; }
        public byte[] BracoEsquerdo { get; set; }
        public byte[] PernaDireita { get; set; }
        public byte[] PernaEsquerda { get; set; }
        public byte[] Corpo { get; set; }
        public byte[] Cabeca { get; set; }
        public byte[] CabecaDesperta { get; set; }
        public int Nivel { get; set; }
        public bool IsVip { get; set; }
        public int ValorCash { get; set; }

    }
}
