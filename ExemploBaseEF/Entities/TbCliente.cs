using System;
using System.Collections.Generic;

namespace ExemploBaseEF.Entities
{
    public enum TipoPessoa
    {
        Juridica = 1,
        Fisica = 2
    }
    public partial class TbCliente: BaseEntity
    {
        public TbCliente()
        {
            TbClienteContato = new HashSet<TbClienteContato>();
            TbClienteEndereco = new HashSet<TbClienteEndereco>();
        }

        //public long IdCliente { get; set; }
        public byte TpPessoa { get; set; }
        public string RazaoSocial { get; set; }
        public string Fantasia { get; set; }
        public string Obs { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public byte IndIe { get; set; }
        public string Cnpj { get; set; }
        public string Suframa { get; set; }
        public string Ie { get; set; }
        public string Im { get; set; }
        public byte? OptanteSn { get; set; }
        public byte Inativo { get; set; }
        public long IdEmpresa { get; set; }
        public DateTime? UltimaAlteracao { get; set; }

        public ICollection<TbClienteContato> TbClienteContato { get; set; }
        public ICollection<TbClienteEndereco> TbClienteEndereco { get; set; }
    }
}
