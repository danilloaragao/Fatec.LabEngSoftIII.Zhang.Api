using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
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

        public Usuario PegarUsuarioPeloEmail(string email)
        {
            return Context.Usuarios.FirstOrDefault(u => u.Email.Equals(email));
        }

        public string CadastrarUsuario(Usuario usuario)
        {
          this.Context.Usuarios.Add(usuario);
          this.Context.SaveChanges();
          return "Cadastro efetuado com sucesso";  
        }
    }
}
