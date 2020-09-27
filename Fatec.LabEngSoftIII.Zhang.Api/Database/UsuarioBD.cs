using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
using System.Linq;
using Fatec.LabEngSoftIII.Zhang.API.Utils;

namespace Fatec.LabEngSoftIII.Zhang.Api.Database
{
    public class UsuarioBD
    {
        private readonly Context Context = new Context();

        public Usuario PegarUsuarioPeloLogin(string login)
        {
            return Context.Usuarios.FirstOrDefault(u => u.Login.Equals(login));
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
          return "Cadastro efetuado com sucesso";  
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            Usuario usuarioBD = Context.Usuarios.FirstOrDefault(u => u.Id == usuario.Id);
            usuarioBD.Senha = usuario.Senha;
            usuarioBD.Email = usuario.Email;

            Context.SaveChanges();
        }
    }
}
