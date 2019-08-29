namespace ExemploBaseEF.Infra.Data.Mapping
{
    using ExemploBaseEF.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ClienteEnderecoMap : BaseEntityConfiguration<TbClienteEndereco>
    {

        public override void Configure(EntityTypeBuilder<TbClienteEndereco> entity)

        {
            //Obrigatório chamar
            base.Configure(entity);
            entity.HasKey(e => e.Id);

            entity.ToTable("tb_cliente_endereco");

            entity.HasIndex(e => e.IdCidade)
                .HasName("ik_Id_Cidade");

            entity.HasIndex(e => e.Id)
                .HasName("IX_tb_cliente_endereco");

            entity.Property(e => e.Id)
                .HasColumnName("Id_Cliente_Endereco");

            entity.Property(e => e.IdCliente)
                .HasColumnName("Id_Cliente");

            entity.Property(e => e.Bairro)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Cep)
                .HasColumnName("CEP")
                .HasMaxLength(8)
                .IsUnicode(false);

            entity.Property(e => e.Complemento)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.IdCidade)
                .HasColumnName("Id_Cidade")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.IdEstado)
                .HasColumnName("Id_Estado")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.IdPais)
                .HasColumnName("Id_Pais")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.Logradouro)
                .HasMaxLength(70)
                .IsUnicode(false);

            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.PtoReferencia)
                .HasMaxLength(2500)
                .IsUnicode(false);

            entity.HasOne(d => d.TbCidade)
              .WithMany(p => p.TbClienteEndereco)
              .HasForeignKey(d => d.IdCidade)
              .HasConstraintName("fk_tb_cliente_endereco_tb_cidade");

            entity.HasOne(d => d.TbCliente)
                .WithMany(p => p.TbClienteEndereco)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tb_cliente_endereco_tb_cliente");

            entity.HasOne(d => d.TbEstado)
                .WithMany(p => p.TbClienteEndereco)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("fk_tb_cliente_endereco_tb_estado");

            entity.HasOne(d => d.TbPais)
                .WithMany(p => p.TbClienteEndereco)
                .HasForeignKey(d => d.IdPais)
                .HasConstraintName("fk_tb_cliente_endereco_tb_pais");

        }
    }
}
