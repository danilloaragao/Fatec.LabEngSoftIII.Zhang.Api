using Fatec.LabEngSoftIII.Zhang.Api.Database;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades.Entradas;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades.Saidas;
using Fatec.LabEngSoftIII.Zhang.API.Utils;
using System.Collections.Generic;

namespace Fatec.LabEngSoftIII.Zhang.Api.Handles
{
    public class UsuarioHandler
    {
        private readonly UsuarioBD UsuarioBD = new UsuarioBD();
        private readonly Criptografia Criptografia = new Criptografia();
        private readonly Email Email = new Email();
        public RespUsuario Login(ReqCredenciais credenciais)
        {
            Usuario usuarioBD = UsuarioBD.PegarUsuarioPeloLogin(credenciais.Login);

            if (usuarioBD == null || !credenciais.Senha.Equals(Criptografia.Decriptografar(usuarioBD.Senha)))
                return null;

            return RespUsuario.MontarRespUsuario(usuarioBD);
        }
        
        public string Cadastro(ReqCadastro usuario)
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

            Usuario usuarioCadastro = new Usuario()
            {
                Email = usuario.Email,
                Experiencia = 0,
                Login = usuario.Login,
                Senha = usuario.Senha,
                IsAdmin = false
            };

            return this.UsuarioBD.CadastrarUsuario(usuarioCadastro);
        }

        public string AtualizarUsuario(ReqAtualizacaoUsuario usuario)
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

            if (inconsistencias.Count > 0)
                return string.Join(" - ", inconsistencias);

            usuario.Senha = Criptografia.Criptografar(usuario.Senha);

            UsuarioBD.AtualizarUsuario(usuario);

            return "Dados atualizados com sucesso";

        }
        public string LembrarSenha(string Email)
        {
            Usuario usuario = UsuarioBD.LembrarSenha(Email);
            if (usuario == null)
                return ("Login ou Email não encontrado na base de dados");

            string assunto = "Recuperação da Senha";

            string corpo = $@"
            <html>
            Olá, <b>{usuario.Login}!
            <br>
            <br>
            Suas credenciais para acesso ao jogo da forca Z-Hang são as seguintes:
            <br>
            <br>
            Login: <b>{usuario.Login}</b><br>
            Senha: <b>{this.Criptografia.Decriptografar(usuario.Senha)}</b>
            <br>
            <br>
            <br>
            <br>
            <i>Este email é enviado de forma automática. Favor não responder.</i>
            </html>";

            this.Email.EnviarEmail(usuario.Email, assunto, corpo);
            return "Sua senha foi encaminhada para o e-mail cadastrado.";
        }
    }
}
