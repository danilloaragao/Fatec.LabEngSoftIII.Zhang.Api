using Fatec.LabEngSoftIII.Zhang.Api.Database;
using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fatec.LabEngSoftIII.Zhang.Api.Handles
{
    public class SkinHandler
    {
        readonly private SkinBD SkinBD = new SkinBD();
        public List<Skin> PegarSkinsPorDescricao(string descricaoSkin)
        {
            if (string.IsNullOrWhiteSpace(descricaoSkin))
                return null;

            return this.SkinBD.PegarSkinsPorDescricao(descricaoSkin);
        }

        public List<Skin> PegarSkinsPorNivel(int? nivel)
        {
            if (nivel == null)
                return null;

            return this.SkinBD.PegarSkinsPorNivel(nivel ?? 0);
        }

        public Skin PegarSkin(int? id)
        {
            if (id == null)
                return null;

            return this.SkinBD.PegarSkin(id ?? 0);
        }

        public List<Skin> PegarSkins()
        {
            return this.SkinBD.PegarSkins();
        }

        public string InsereSkin(Skin skin)
        {
            if (skin == null)
                return "Falha ao receber as informações da skin";

            if (string.IsNullOrWhiteSpace(skin.Descricao))
                return "A descrição não pode estar em branco";

            List<Skin> skins = PegarSkinsPorDescricao(skin.Descricao);

            if (skins.Any(t => t.Descricao.ToUpper().Equals(skin.Descricao.ToUpper())))
                return "Skin já existe no banco de dados";

            return this.SkinBD.InsereSkin(skin);
        }

        public string AlteraSkin(Skin skin)
        {
            if (skin == null)
                return "Falha ao receber as informações da skin";

            if (string.IsNullOrWhiteSpace(skin.Descricao))
                return "A descrição não pode estar em branco";

            List<Skin> skins = PegarSkinsPorDescricao(skin.Descricao);

            if (skins.Any(t => t.Descricao.ToUpper().Equals(skin.Descricao.ToUpper())))
                return "Skin já existe no banco de dados";

            return this.SkinBD.AlteraSkin(skin);
        }

        public string DeletaSkin(int? idSkin)
        {
            if (idSkin == null)
                return null;

            Skin skinBd = PegarSkin(idSkin ?? 0);

            if (skinBd == null)
                return "Id não encontrado no banco de dados";

            return this.SkinBD.DeletaSkin(idSkin ?? 0);
        }
    }
}
