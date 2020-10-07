using Fatec.LabEngSoftIII.Zhang.Api.Entidades;
using Fatec.LabEngSoftIII.Zhang.Api.Utils;
using Microsoft.EntityFrameworkCore;

namespace Fatec.LabEngSoftIII.Zhang.Api.Database
{
    public class Context : DbContext
    {
        private string ConnectionString { get; set; }

        public Context()
        {
            Config config = new Config();
            this.ConnectionString = config.ConnetionString;
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioSkin> UsuarioSkins { get; set; }
        public DbSet<Skin> Skins { get; set; }
        public DbSet<Experiencia> Experiencia { get; set; }
        public DbSet<PalavraJogo> Palavras { get; set; }
        public DbSet<Tema> Temas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseNpgsql(this.ConnectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("USUARIO");

                entity.HasKey(e => e.Id)
                    .HasName("ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID");

                entity.Property(e => e.Login)
                    .HasColumnName("LOGIN");

                entity.Property(e => e.Senha)
                    .HasColumnName("SENHA");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Experiencia)
                    .HasColumnName("EXPERIENCIA");

                entity.Property(e => e.IsAdmin)
                    .HasColumnName("IS_ADMIN");

                entity.Property(e => e.Cash)
                    .HasColumnName("CASH");
            });

            modelBuilder.Entity<UsuarioSkin>(entity =>
            {
                entity.ToTable("USUARIO_SKIN");

                entity.HasKey(e => e.Id)
                    .HasName("ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("ID_USUARIO");

                entity.Property(e => e.IdSkin)
                    .HasColumnName("ID_SKIN");

                entity.Property(e => e.Ativo)
                    .HasColumnName("ATIVO");
            });

            modelBuilder.Entity<Skin>(entity =>
            {
                entity.ToTable("SKIN");

                entity.HasKey(e => e.Id)
                    .HasName("ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID");

                entity.Property(e => e.Descricao)
                    .HasColumnName("DESCRICAO");

                entity.Property(e => e.BracoDireito)
                    .HasColumnName("BRACO_DIREITO");

                entity.Property(e => e.BracoEsquerdo)
                    .HasColumnName("BRACO_ESQUERDO");

                entity.Property(e => e.PernaDireita)
                    .HasColumnName("PERNA_DIREITA");

                entity.Property(e => e.PernaEsquerda)
                    .HasColumnName("PERNA_ESQUERDA");

                entity.Property(e => e.Corpo)
                    .HasColumnName("CORPO");

                entity.Property(e => e.Cabeca)
                    .HasColumnName("CABECA");

                entity.Property(e => e.CabecaDesperta)
                    .HasColumnName("CABECA_DESPERTA");

                entity.Property(e => e.Nivel)
                    .HasColumnName("NIVEL");

                entity.Property(e => e.IsVip)
                    .HasColumnName("IS_VIP");

                entity.Property(e => e.ValorCash)
                    .HasColumnName("VALOR_CASH");
            });

            modelBuilder.Entity<Experiencia>(entity =>
            {
                entity.ToTable("EXPERIENCIA");

                entity.HasKey(e => e.Id)
                     .HasName("ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID");

                entity.Property(e => e.Valor)
                    .HasColumnName("VALOR");

                entity.Property(e => e.Nivel)
                    .HasColumnName("NIVEL");
            });

            modelBuilder.Entity<PalavraJogo>(entity =>
            {
                entity.ToTable("PALAVRA");

                entity.HasKey(e => e.Id)
                    .HasName("ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID");

                entity.Property(e => e.IdTema)
                    .HasColumnName("ID_TEMA");

                entity.Property(e => e.Palavra)
                    .HasColumnName("PALAVRA");

                entity.Property(e => e.Dica1)
                    .HasColumnName("DICA_1");

                entity.Property(e => e.Dica2)
                    .HasColumnName("DICA_2");
            });

            modelBuilder.Entity<Tema>(entity =>
            {
                entity.ToTable("TEMA");

                entity.HasKey(e => e.Id)
                    .HasName("ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID");

                entity.Property(e => e.Descricao)
                    .HasColumnName("DESCRICAO");
            });
        }
    }
}
