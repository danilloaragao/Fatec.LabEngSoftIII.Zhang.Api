using Fatec.LabEngSoftIII.Zhang.Api.Database;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fatec.LabEngSoftIII.Zhang.Api.Handles
{
    public class PalavraHandler
    {
        private PalavraBD _palavraBD = new PalavraBD();
        public List<PalavraJogo> PegarPalavrasPorTema(string tema)
        {
            if (string.IsNullOrWhiteSpace(tema))
                return null;

            return this._palavraBD.PegarPalavrasPorTema(tema);
        }

        public PalavraJogo PegarPalavra(int id)
        {
            return this._palavraBD.PegarPalavra(id);
        }

        public List<PalavraJogo> PegarPalavrasPorTrecho(string palavra)
        {
            if (string.IsNullOrWhiteSpace(palavra))
                return null;

            return this._palavraBD.PegarPalavrasPorTrecho(palavra);
        }

        public List<PalavraJogo> PegarTodasPalavras()
        {
            return this._palavraBD.PegarTodasPalavras();
        }

        public string InserePalavra(PalavraJogo palavra)
        {
            List<string> incosistencias = new List<string>();

            if (string.IsNullOrWhiteSpace(palavra.Palavra))
                incosistencias.Add("A palavra não pode estar em branco");
            else
            {
                List<PalavraJogo> palavras = PegarPalavrasPorTrecho(palavra.Palavra);

                if (palavras.Any(p => p.Palavra.ToUpper().Equals(palavra.Palavra.ToUpper())))
                    return "Palavra já existe no banco de dados";
            }

            TemaHandler temaHandler = new TemaHandler();
            Tema tema = temaHandler.PegarTema(palavra.IdTema);

            if (tema == null)
                incosistencias.Add("Id do tema não encontrado no banco de dados");

            if (string.IsNullOrWhiteSpace(palavra.Dica1))
                incosistencias.Add("A primeira dica não pode estar em branco");

            if (string.IsNullOrWhiteSpace(palavra.Dica2))
                incosistencias.Add("A segunda dica não pode estar em branco");

            if (incosistencias.Count > 0)
                return string.Join(" - ", incosistencias);

            return this._palavraBD.InserePalavra(palavra);
        }

        public string AlteraPalavra(PalavraJogo palavra)
        {
            List<string> incosistencias = new List<string>();

            PalavraJogo palavraBd = PegarPalavra(palavra.Id);

            if (palavraBd == null)
                return "Id não existe no banco de dados";


            if (string.IsNullOrWhiteSpace(palavra.Palavra))
                incosistencias.Add("A palavra não pode estar em branco");
           

            TemaHandler temaHandler = new TemaHandler();
            Tema tema = temaHandler.PegarTema(palavra.IdTema);

            if (tema == null)
                incosistencias.Add("Id do tema não encontrado no banco de dados");

            if (string.IsNullOrWhiteSpace(palavra.Dica1))
                incosistencias.Add("A primeira dica não pode estar em branco");

            if (string.IsNullOrWhiteSpace(palavra.Dica2))
                incosistencias.Add("A segunda dica não pode estar em branco");

            if (incosistencias.Count > 0)
                return string.Join(" - ", incosistencias);

            return this._palavraBD.AlteraPalavra(palavra);
        }

        public string DeletaPalavra(int idPalavra)
        {
            PalavraJogo palavraBd = PegarPalavra(idPalavra);

            if (palavraBd == null)
                return "Id não existe no banco de dados";

            return this._palavraBD.DeletaPalavra(idPalavra);
        }
    }
}
