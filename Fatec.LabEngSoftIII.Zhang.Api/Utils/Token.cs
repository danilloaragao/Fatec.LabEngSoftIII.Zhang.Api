using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
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
        private string _key { get; set; }

        public Token()
        {
            Config config = new Config();
            this._key = config.ChaveCriptografia;
        }

        public string Gerar(string nome, int id)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, id.ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, nome),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._key));
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
            var tokenLido = new JwtSecurityTokenHandler().ReadJwtToken(token);

            Usuario usuario = new Usuario();
            string login = tokenLido.Claims.Where(e => e.Type.Equals("unique_name")).FirstOrDefault().Value;
            int id = int.Parse(tokenLido.Claims.Where(e => e.Type.Equals("nameid")).FirstOrDefault().Value);

            string novoToken = Gerar(login, id);

            return token.Equals(novoToken);
        }
    }
}
