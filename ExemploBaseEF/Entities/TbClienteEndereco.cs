using System;
using System.Collections.Generic;

namespace ExemploBaseEF.Entities
{
    public enum TipoEndereco
    {
        Sede = 1,
        Entrega = 2,
        Cobranca = 3,
        Postagem = 4
    }
    public partial class TbClienteEndereco: BaseEntity
    {
        //public long IdClienteEndereco { get; set; }
        public long IdCliente { get; set; }
        public byte TpEndereco { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public long? IdCidade { get; set; }
        public long? IdEstado { get; set; }
        public long? IdPais { get; set; }
        public string PtoReferencia { get; set; }

        public TbCidade TbCidade { get; set; }
        public TbCliente TbCliente { get; set; }
        public TbEstado TbEstado { get; set; }
        public TbPais TbPais { get; set; }
    }
}
