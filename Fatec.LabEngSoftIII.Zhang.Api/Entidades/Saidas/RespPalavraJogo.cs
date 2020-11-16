using Fatec.LabEngSoftIII.Zhang.Api.Utils;
using System;
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

        public static RespPalavraJogo MontarResposta(PalavraJogo palavra, int quantidadeLetras)
        {
            Random random = new Random();
            List<string> todasLetras = new List<string> { "A", "B", "C", "Ç", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "Y", "X", "Z" };

            List<string> letras = new List<string>();
            palavra.Palavra = palavra.Palavra.ToUpper().RemoverAcentos();

            foreach (char letra in palavra.Palavra)
            {
                if (!letras.Contains(letra.ToString()))
                {
                    letras.Add(letra.ToString());
                    todasLetras.Remove(letra.ToString());
                }
            }
            int quatidadeTotalLetras = letras.Count + quantidadeLetras;

            while (letras.Count < quatidadeTotalLetras && todasLetras.Count !=0)
            {
                int index = random.Next(todasLetras.Count);
                letras.Add(todasLetras[index]);
                todasLetras.RemoveAt(index);
            }

            letras.Sort();

            RespPalavraJogo retorno = new RespPalavraJogo()
            {
                Id = palavra.Id,
                Palavra = palavra.Palavra,
                Dica1 = palavra.Dica1,
                Dica2 = palavra.Dica2,
                Letras = letras
            };

            return retorno;
        }
    }
}
