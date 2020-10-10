using Fatec.LabEngSoftIII.Zhang.Api.Database;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades.Entradas;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades.Saidas;
using Fatec.LabEngSoftIII.Zhang.API.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fatec.LabEngSoftIII.Zhang.Api.Handles
{
    public class SuperUsuarioHandler
    {
        private readonly UsuarioBD UsuarioBD = new UsuarioBD();
        private readonly UsuarioHandler UsuarioHandler = new UsuarioHandler();
        private readonly Token Token = new Token();
        private readonly Criptografia Criptografia = new Criptografia();

        public RespAdm Login(ReqCredenciais credenciais)
        {
            Usuario usuarioBD = UsuarioBD.PegarAdmPeloLogin(credenciais.Login);

            if (usuarioBD == null || !credenciais.Senha.Equals(Criptografia.Decriptografar(usuarioBD.Senha)))
                return null;

            return MontarRespAdm(usuarioBD);
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

            string senha = new Guid().ToString().Substring(6);

            Usuario usuarioCadastro = new Usuario()
            {
                Email = usuario.Email,
                Experiencia = 0,
                Login = usuario.Login,
                Senha = Criptografia.Criptografar(senha),
                IsAdmin = true
            };

            string retorno = this.UsuarioBD.CadastrarUsuario(usuarioCadastro);

            UsuarioHandler.LembrarSenha(usuarioCadastro.Email);

            return retorno;
        }

        public RespAdm MontarRespAdm(Usuario usuarioBD)
        {
            RespAdm usuario = new RespAdm
            {
                Id = usuarioBD.Id,
                Login = usuarioBD.Login,
                Email = usuarioBD.Email
            };

            usuario.Token = Token.Gerar(usuario.Login, usuario.Id, usuarioBD.IsAdmin);

            return usuario;
        }
    }
}
