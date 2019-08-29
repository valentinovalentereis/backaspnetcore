using System;
using System.Collections.Generic;

namespace ExemploBaseEF.Entities
{
    public partial class TbEstado: BaseEntity
    {
        public TbEstado()
        {
            TbCidade = new HashSet<TbCidade>();
            TbClienteEndereco = new HashSet<TbClienteEndereco>();
        }

        //public long IdEstado { get; set; }
        public long IdPais { get; set; }
        public long CodigoIbge { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }

        public TbPais IdPaisNavigation { get; set; }
        public ICollection<TbCidade> TbCidade { get; set; }
        public ICollection<TbClienteEndereco> TbClienteEndereco { get; set; }
    }
}
