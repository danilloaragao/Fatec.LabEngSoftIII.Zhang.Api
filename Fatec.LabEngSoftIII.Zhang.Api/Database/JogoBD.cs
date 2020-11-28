using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades.Entradas;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades.Saidas;
using System.Collections.Generic;
using System.Linq;

namespace Fatec.LabEngSoftIII.Zhang.Api.Database
{
    public class JogoBD
    {
        readonly private Context Context = new Context();

        public List<Experiencia> PegarExperiencias()
        {
            return Context.Experiencia.ToList();
        }

        public List<RespSkin> PegarSkinsUsuario(int id)
        {
            List<RespSkin> retorno = new List<RespSkin>();

            List<UsuarioSkin> usuarioSkins = Context.UsuarioSkins.Where(u => u.IdUsuario == id).ToList();

            foreach (UsuarioSkin usuarioSkin in usuarioSkins)
            {
                Skin infoSkin = PegarSkinPeloId(usuarioSkin.IdSkin);

                if (infoSkin == null)
                    continue;

                RespSkin respSkin = new RespSkin
                {
                    Id = usuarioSkin.IdSkin,
                    Ativo = usuarioSkin.Ativo,
                    Nivel = infoSkin.Nivel,
                    Descricao = infoSkin.Descricao,
                    Sprite = infoSkin.Sprite,
                    JumpScare = infoSkin.JumpScare
                };
                retorno.Add(respSkin);
            }
            return retorno;
        }

        public Skin PegarSkinPeloId(int id)
        {
            return Context.Skins.Where(s => s.Id == id).FirstOrDefault();
        }

        public Skin PegarSkinVipPeloId(int id)
        {
            return Context.Skins.Where(s => s.Id == id && s.IsVip).FirstOrDefault();
        }

        public void AlteracaoSkins(List<ReqSkin> skins, int idUsuario)
        {
            foreach (ReqSkin skin in skins)
            {
                UsuarioSkin usuarioSkin = this.Context.UsuarioSkins.FirstOrDefault(u => u.IdUsuario == idUsuario && u.IdSkin == skin.Id);

                if (usuarioSkin == null)
                    continue;

                usuarioSkin.Ativo = skin.Ativo;
            }
            this.Context.SaveChanges();
        }

        public void AcertoPalavra(int experienciaGanha, int idUsuario)
        {
            Usuario usuario = this.Context.Usuarios.FirstOrDefault(u => u.Id == idUsuario);

            usuario.Experiencia += experienciaGanha;

            this.Context.SaveChanges();
        }

        public void AtualizarSkins(RespUsuario usuario)
        {
            List<Skin> skins = Context.Skins.Where(s => s.Nivel == usuario.Nivel && !s.IsVip).ToList();

            foreach (Skin skin in skins)
            {
                UsuarioSkin usuarioSkin = new UsuarioSkin()
                {
                    IdSkin = skin.Id,
                    IdUsuario = usuario.Id,
                    Ativo = false
                };

                Context.UsuarioSkins.Add(usuarioSkin);
            }
            Context.SaveChanges();
        }

        public void ComprarSkin(int idSkin, int idUsuario)
        {
            UsuarioSkin usuarioSkin = new UsuarioSkin
            {
                IdSkin = idSkin,
                IdUsuario = idUsuario,
                Ativo = false
            };
            Context.UsuarioSkins.Add(usuarioSkin);
            Context.Usuarios.FirstOrDefault(u => u.Id == idUsuario).Cash -= Context.Skins.FirstOrDefault(s => s.Id == idSkin).ValorCash;
            Context.SaveChanges();
        }

        public List<Usuario> TopCinco()
        {
            return Context.Usuarios.Where(u => !u.IsAdmin).OrderByDescending(u => u.Experiencia).Take(5).ToList();
        }

        public int PegarColocacaoPelaExperiencia(int experiencia)
        {
            return Context.Usuarios.Where(u => !u.IsAdmin).Count(u => u.Experiencia > experiencia) + 1;
        }

        public bool ExisteUsuarioSkin(int idSkin, int idUsuario)
        {
            return Context.UsuarioSkins.Any(u => u.IdSkin == idSkin && u.IdUsuario == idUsuario);
        }

        public List<Skin> PegarSkinsVip()
        {
            return Context.Skins.Where(s => s.IsVip).ToList();
        }

        public List<PalavraJogo> ObterPalavras(string tema)
        {
            if (string.IsNullOrWhiteSpace(tema))
                return this.Context.Palavras.ToList();
            else
            {
                return this.Context.Palavras.Where(p => 
                                            p.IdTema == this.Context.Temas.FirstOrDefault(t => t.Descricao.ToUpper().Equals(tema.ToUpper())).Id
                                            ).ToList();
            }
        }
    }
}
