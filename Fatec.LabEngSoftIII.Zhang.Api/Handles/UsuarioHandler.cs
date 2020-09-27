using Fatec.LabEngSoftIII.Zhang.Api.Database;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades.Entradas;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades.Saidas;
using Fatec.LabEngSoftIII.Zhang.API.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Fatec.LabEngSoftIII.Zhang.Api.Handles
{
    public class UsuarioHandler
    {
        private readonly UsuarioBD UsuarioBD = new UsuarioBD();
        private readonly JogoBD JogoBD = new JogoBD();
        private readonly Token Token = new Token();
        private readonly Criptografia Criptografia = new Criptografia();

        public RespUsuario Login(ReqCredenciais credenciais)
        {
            Usuario usuarioBD = UsuarioBD.PegarUsuarioPeloLogin(credenciais.Login);

            if (usuarioBD == null || !credenciais.Senha.Equals(Criptografia.Decriptografar(usuarioBD.Senha)))
                return null;

            return MontarRespUsuario(usuarioBD);
        }
        
        public string Cadastro(Usuario usuario)
        { 
            if (usuario == null)
                return "Falha ao receber as informações do usuario";

            List<string> inconsistencias = new List<string>();

            if (string.IsNullOrWhiteSpace(usuario.Login))
                inconsistencias.Add("Login não pode estar em branco");
            else
            {
                if (usuario.Login.Length < 4)
                    inconsistencias.Add("Login deve ter no mínimo 4 caracteres");
                else{
                    if (this.UsuarioBD.PegarUsuarioPeloLogin(usuario.Login) != null)
                        inconsistencias.Add("Este login já está em uso");
                }                
            }

            if (string.IsNullOrWhiteSpace(usuario.Senha))
                inconsistencias.Add("Senha não pode estar em branco");
            else
            {
                if (usuario.Senha.Length < 6)
                    inconsistencias.Add("Senha deve ter no mínimo 6 caracteres");                
            }

            if (string.IsNullOrWhiteSpace(usuario.Email))
                inconsistencias.Add("Email não pode estar em branco");
            else
            {
                if (!usuario.Email.Contains("@"))
                    inconsistencias.Add("Email inválido");
                else{
                    if (this.UsuarioBD.PegarUsuarioPeloEmail(usuario.Email) != null)
                        inconsistencias.Add("Email já foi cadastrado");
                }                          
            }
            
            if (inconsistencias.Count > 0)
                return string.Join(" - ", inconsistencias);

            usuario.Senha = Criptografia.Criptografar(usuario.Senha);

            return this.UsuarioBD.CadastrarUsuario(usuario);
        }

        public RespUsuario MontarRespUsuario(Usuario usuarioBD)
        {
            RespUsuario usuario = new RespUsuario
            {
                Id = usuarioBD.Id,
                Login = usuarioBD.Login,
                Email = usuarioBD.Email,
                Experiencia = usuarioBD.Experiencia
            };

            List<Experiencia> experiencia = JogoBD.PegarExperiencias();

            List<Experiencia> niveisAbaixo = experiencia.Where(e => e.Valor < usuario.Experiencia).ToList();

            if (niveisAbaixo == null || niveisAbaixo.Count == 0)
                usuario.Nivel = 0;
            else
                usuario.Nivel = niveisAbaixo.Max(e => e.Nivel);

            List<Experiencia> niveisAcima = experiencia.Where(e => e.Valor > usuario.Experiencia).ToList();

            if (niveisAcima == null || niveisAcima.Count == 0)
                usuario.ExperienciaProximoNivel = 0;
            else
                usuario.ExperienciaProximoNivel = niveisAcima.Min(e => e.Valor) - usuario.Experiencia;

            usuario.Skins = JogoBD.PegarSkinsUsuario(usuario.Id) ?? new List<RespSkin>();
            usuario.Token = Token.Gerar(usuario.Login, usuario.Id);

            return usuario;
        }

        public string AtualizarUsuario(Usuario usuario)
        {
            if (usuario == null)
                return "Falha ao receber as informações do usuario";

            List<string> inconsistencias = new List<string>();

            if (string.IsNullOrWhiteSpace(usuario.Senha))
                inconsistencias.Add("Senha não pode estar em branco");
            else
            {
                if (usuario.Senha.Length < 6)
                    inconsistencias.Add("Senha deve ter no mínimo 6 caracteres");
            }

            if (string.IsNullOrWhiteSpace(usuario.Email))
                inconsistencias.Add("Email não pode estar em branco");
            else
            {
                if (!usuario.Email.Contains("@"))
                    inconsistencias.Add("Email inválido");
            }

            if (inconsistencias.Count > 0)
                return string.Join(" - ", inconsistencias);

            usuario.Senha = Criptografia.Criptografar(usuario.Senha);

            UsuarioBD.AtualizarUsuario(usuario);

            return "Dados atualizados com sucesso";

        }
    }
}
