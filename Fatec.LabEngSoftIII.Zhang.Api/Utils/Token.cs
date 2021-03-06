﻿using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
using Fatec.LabEngSoftIII.Zhang.Api.Utils;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Fatec.LabEngSoftIII.Zhang.API.Utils
{
    public class Token
    {
        private string Key { get; set; }

        public Token()
        {
            Config config = new Config();
            this.Key = config.ChaveCriptografia;
        }

        public string Gerar(string nome, int id, bool isAdm)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, id.ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, nome),
                new Claim("isadm", isAdm ? "1" : "0"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               claims: claims,
               expires: null,
               signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool Validar(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return false;

            string tokenLimpo = token.Replace("Bearer", "").Replace("Authentication", "").Trim();
            var tokenLido = new JwtSecurityTokenHandler().ReadJwtToken(tokenLimpo);

            Usuario usuario = new Usuario();
            string login = tokenLido.Claims.Where(e => e.Type.Equals("nameid")).FirstOrDefault().Value;
            int id = int.Parse(tokenLido.Claims.Where(e => e.Type.Equals("unique_name")).FirstOrDefault().Value);
            bool isAdm = int.Parse(tokenLido.Claims.Where(e => e.Type.Equals("isadm")).FirstOrDefault().Value) == 1;

            string novoToken = Gerar(login, id, isAdm);

            return tokenLimpo.Equals(novoToken);
        }

        public bool ValidarAdm(string token)
        {
            if (!Validar(token))
                return false;

            var tokenLido = new JwtSecurityTokenHandler().ReadJwtToken(token);

            return int.Parse(tokenLido.Claims.Where(e => e.Type.Equals("isadm")).FirstOrDefault().Value) == 1;
        }

        public int PegarId(string token)
        {
            var tokenLido = new JwtSecurityTokenHandler().ReadJwtToken(token);
            return int.Parse(tokenLido.Claims.Where(e => e.Type.Equals("unique_name")).FirstOrDefault().Value);
        }
    }
}
