using ExemploBaseEF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExemploBaseEF.Infra.Data.Mapping
{
    public class ClienteMap: BaseEntityConfiguration<TbCliente>
    {
        public override void Configure(EntityTypeBuilder<TbCliente> entity)

        {
            //Obrigatório chamar
            base.Configure(entity);

            entity
                .ToTable("tb_cliente");

            entity
                .HasKey(e => e.Id);
            
            // Indices
            entity
                .HasIndex(e => e.Cnpj)
                .HasName("ik_CNPJ");

            entity.HasIndex(e => e.Cpf)
                .HasName("ik_CPF");

            entity.Property(e => e.Id)
                .HasColumnName("Id_Cliente");

            entity.Property(e => e.Cnpj)
                .IsRequired()
                .HasColumnName("CNPJ")
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            entity.Property(e => e.Cpf)
                .HasColumnName("CPF")
                .HasMaxLength(14)
                .IsUnicode(false);

            entity.Property(e => e.Fantasia)
                .IsRequired()
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            entity
                .Property(e => e.IdEmpresa)
                .HasColumnName("Id_Empresa");

            entity.Property(e => e.Ie)
                .HasColumnName("IE")
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Im)
                .HasColumnName("IM")
                .HasMaxLength(20)
                .IsUnicode(false);

            entity
                .Property(e => e.IndIe)
                .HasColumnName("IndIE");

            entity
                .Property(e => e.Obs)
                .HasMaxLength(2500)
                .IsUnicode(false);

            entity
                .Property(e => e.OptanteSn)
                .HasColumnName("OptanteSN")
                .HasDefaultValueSql("((0))");

            entity
                .Property(e => e.RazaoSocial)
                .IsRequired()
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            entity
                .Property(e => e.Rg)
                .HasColumnName("RG")
                .HasMaxLength(15)
                .IsUnicode(false);

            entity
                .Property(e => e.Suframa)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity
                .Property(e => e.UltimaAlteracao)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
        }
    }
}
