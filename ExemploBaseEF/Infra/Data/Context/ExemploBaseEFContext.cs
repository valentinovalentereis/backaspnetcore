using Microsoft.EntityFrameworkCore;
using ExemploBaseEF.Entities;
//using Microsoft.Extensions.Configuration;
using ExemploBaseEF.Infra.Data.Mapping;

namespace ExemploBaseEF.Infra.Data.Context
{
    public partial class ExemploBaseEFContext : DbContext
    {
        public ExemploBaseEFContext()
        {
        }

        public ExemploBaseEFContext(DbContextOptions<ExemploBaseEFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbCidade> TbCidade { get; set; }
        public virtual DbSet<TbCliente> TbCliente { get; set; }
        public virtual DbSet<TbClienteContato> TbClienteContato { get; set; }
        public virtual DbSet<TbClienteEndereco> TbClienteEndereco { get; set; }
        public virtual DbSet<TbEstado> TbEstado { get; set; }
        public virtual DbSet<TbPais> TbPais { get; set; }
        public virtual DbSet<TbUsuario> TbUsuario { get; set; }
        public virtual DbSet<TbUsuarioConta> UsuarioConta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /*
               To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
               */
                optionsBuilder.UseSqlServer("Data Source=WELLINGTON-HP\\SQLEXPRESS;Initial Catalog=exemplos;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TbCliente>(new ClienteMap().Configure);
            modelBuilder.Entity<TbClienteContato>(new ClienteContatoMap().Configure);
            modelBuilder.Entity<TbClienteEndereco>(new ClienteEnderecoMap().Configure);

            modelBuilder.Entity<TbUsuario>(new UsuarioMap().Configure);
            modelBuilder.Entity<TbUsuarioConta>(new UsuarioContaMap().Configure);
        }
    }
}
