using System;
using System.Collections.Generic;

namespace ExemploBaseEF.Entities
{
    public enum TipoTelefone
    {
        Sede = 1,
        Entrega = 2,
        Cobranca = 3,
        Postagem = 4
    }
    public partial class TbClienteContato :BaseEntity
    {
        //public long IdClienteContato { get; set; }
        public long IdCliente { get; set; }
        public string Descricao { get; set; }
        public string Departamento { get; set; }
        public string Email { get; set; }
        public byte TpTelefone { get; set; }
        public string Ddd { get; set; }
        public string Ramal { get; set; }
        public string Telefone { get; set; }
        public string Cargo { get; set; }
        public string NomeContato { get; set; }

        public TbCliente TbCliente { get; set; }
    }
}
