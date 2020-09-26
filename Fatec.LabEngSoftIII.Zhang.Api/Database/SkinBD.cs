using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Fatec.LabEngSoftIII.Zhang.Api.Database
{
    public class SkinBD
    {
        readonly private Context Context = new Context();

        public List<Skin> PegarSkinsPorDescricao(string descricaoSkin)
        {
            return this.Context.Skins.Where(s => s.Descricao.Contains(descricaoSkin)).ToList();
        }

        public List<Skin> PegarSkinsPorNivel(int? nivel)
        {
            if (nivel == null)
                return null;

            return this.Context.Skins.Where(s => s.Nivel == nivel).OrderBy(s => s.Nivel).ToList();
        }

        public Skin PegarSkin(int? id)
        {
            if (id == null)
                return null;

            return this.Context.Skins.FirstOrDefault(s => s.Id == id);
        }

        public List<Skin> PegarSkins()
        {
            return this.Context.Skins.ToList();
        }

        public string InsereSkin(Skin skin)
        {
            this.Context.Skins.Add(skin);
            this.Context.SaveChanges();
            return "Skin cadastrada com sucesso";
        }

        public string AlteraSkin(Skin skin)
        {
            Skin skinBd = this.Context.Skins.FirstOrDefault(s => s.Id == skin.Id);

            skinBd.Descricao = skin.Descricao;
            skinBd.Nivel = skin.Nivel;

            this.Context.SaveChanges();

            return "Tema atualizado com sucesso";
        }

        public string DeletaSkin(int? idSkin)
        {
            Skin skinBd = this.Context.Skins.FirstOrDefault(s => s.Id == idSkin);

            this.Context.Skins.Remove(skinBd);
            this.Context.SaveChanges();
            return "Tema deletado com sucesso.";
        }
    }
}
