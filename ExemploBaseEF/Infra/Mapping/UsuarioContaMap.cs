using ExemploBaseEF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExemploBaseEF.Infra.Data.Mapping
{
    public class UsuarioContaMap : BaseEntityConfiguration<TbUsuarioConta>
    {
        public override void Configure(EntityTypeBuilder<TbUsuarioConta> entity)

        {
            //Obrigatório chamar
            base.Configure(entity);

            entity.ToTable("tb_usuario_conta");

            entity.HasKey(e => e.Id);

            entity
                .Property(e => e.Id)
                .HasColumnName("Id_Usuario_Conta");

            entity
                .Property(e => e.IdUsuario)
                .HasColumnName("Id_Usuario")
                .IsRequired();

            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(70)
                .IsUnicode(false);

            entity.Property(e => e.Sobrenome)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Apelido)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);
            entity
                .Property(e => e.TpDocumento)
                .HasColumnName("TpDocumento");

            entity.Property(e => e.Documento)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.Property(e => e.Email)
                .HasColumnName("EMail")
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}
