using ExemploBaseEF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExemploBaseEF.Infra.Data.Mapping
{
    public class UsuarioMap : BaseEntityConfiguration<TbUsuario>
    {
        public override void Configure(EntityTypeBuilder<TbUsuario> entity)

        {
            //Obrigatório chamar
            base.Configure(entity);

            entity
                .ToTable("tb_usuario");

            entity
                .HasKey(e => e.Id);

            entity
                .Property(e => e.Id)
                .HasColumnName("Id_Usuario");

            entity
                .Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity
                .Property(e => e.Senha)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity
                .HasOne(p => p.TbUsuarioConta)
                .WithOne(i => i.TbUsuario)
                .HasForeignKey<TbUsuarioConta>(b => b.IdUsuario);

            /*
            entity.HasOne(d => d.UsuarioConta)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK_tb_usuario_tb_usuario_conta");
                */
        }
    }
}
