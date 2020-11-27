using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades.Entradas;
using System.Linq;

namespace Fatec.LabEngSoftIII.Zhang.Api.Database
{
    public class UsuarioBD
    {
        private readonly Context Context = new Context();

        public Usuario PegarUsuarioPeloLogin(string login)
        {
            return Context.Usuarios.FirstOrDefault(u => u.Login.Equals(login));
        }

        public Usuario PegarAdmPeloLogin(string login)
        {
            return Context.Usuarios.FirstOrDefault(u => u.Login.Equals(login) && u.IsAdmin);
        }

        public Usuario PegarUsuarioPeloEmail(string email)
        {
            return Context.Usuarios.FirstOrDefault(u => u.Email.Equals(email));
        }

        public Usuario PegarUsuarioPeloId(int id)
        {
            Usuario usuario = Context.Usuarios.FirstOrDefault(u => u.Id == id);
            Context.Entry(usuario).Reload();
            return usuario;
        }

        public string CadastrarUsuario(Usuario usuario)
        {
            this.Context.Usuarios.Add(usuario);
            this.Context.SaveChanges();

            int idUsuario = this.Context.Usuarios.FirstOrDefault(u => u.Login.Equals(usuario.Login)).Id;

            this.Context.UsuarioSkins.Add(new UsuarioSkin() 
            {
                IdUsuario = idUsuario,
                IdSkin = 16,
                Ativo = true
            });

            return "Cadastro efetuado com sucesso";
        }

        public void AtualizarUsuario(ReqAtualizacaoUsuario usuario)
        {
            Usuario usuarioBD = Context.Usuarios.FirstOrDefault(u => u.Id == usuario.Id);
            usuarioBD.Senha = usuario.Senha;

            Context.SaveChanges();
        }

        public void CompraCash(int qtdCash, int idUsuario)
        {
            Usuario usuarioBD = Context.Usuarios.FirstOrDefault(u => u.Id == idUsuario);
            usuarioBD.Cash += qtdCash;

            Context.SaveChanges();
        }

        public Usuario LembrarSenha(string Email)
        {
            Usuario usuario = this.Context.Usuarios.FirstOrDefault(u => u.Login.Equals(Email) || u.Email.Equals(Email));
            return usuario;
        }

    }
}
