using System;

namespace Fatec.LabEngSoftIII.Zhang.Api.Utils
{
    public static class Gerador
    {
       public static string Palavra(int quatidadeCaracteres)
        {
            Random random = new Random();
            string texto = "";

            while(texto.Length < quatidadeCaracteres)
            {
                int caractere = random.Next(48, 123);

                if (caractere <= 57 || (caractere >= 65 && caractere <= 90) || caractere >= 97)
                    texto += Convert.ToChar(caractere);
            }
            return texto;
        }
    }
}
