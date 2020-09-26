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
                    Descricao = infoSkin.Descricao
                };
                retorno.Add(respSkin);
            }
            return retorno;
        }

        public Skin PegarSkinPeloId(int id)
        {
            return Context.Skins.Where(s => s.Id == id).FirstOrDefault();
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
    }
}
