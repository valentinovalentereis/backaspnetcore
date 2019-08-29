namespace ExemploBaseEF.Infra.Data.Mapping
{
    using ExemploBaseEF.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ClienteContatoMap : BaseEntityConfiguration<TbClienteContato>
    {
        public override void Configure(EntityTypeBuilder<TbClienteContato> entity)

        {
            //Obrigatório chamar
            base.Configure(entity);
            entity.HasKey(e => e.Id);

            entity.ToTable("tb_cliente_contato");
            
            entity.HasIndex(e => e.Id)
                .HasName("ik_id_cliente");

            entity.Property(e => e.Id).HasColumnName("Id_Cliente_Contato");

            entity.Property(e => e.Cargo).HasMaxLength(50);

            entity.Property(e => e.Ddd)
                .HasColumnName("DDD")
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.Property(e => e.Departamento)
                .HasMaxLength(70)
                .IsUnicode(false);

            entity.Property(e => e.Descricao)
                .HasMaxLength(70)
                .IsUnicode(false);

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.IdCliente)
                    .HasColumnName("Id_Cliente");

            entity.Property(e => e.NomeContato).HasMaxLength(50);

            entity.Property(e => e.Ramal)
                .HasMaxLength(4)
                .IsUnicode(false);

            entity.Property(e => e.Telefone)
                .HasMaxLength(14)
                .IsUnicode(false);

            entity.HasOne(d => d.TbCliente)
                .WithMany(p => p.TbClienteContato)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tb_cliente_contato_tb_cliente");
        }
    }
}
