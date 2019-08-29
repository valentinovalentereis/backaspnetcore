using System;
using System.Collections.Generic;

namespace ExemploBaseEF.Entities
{
    public partial class TbCidade: BaseEntity
    {
        public TbCidade()
        {
            TbClienteEndereco = new HashSet<TbClienteEndereco>();
        }

        //public long IdCidade { get; set; }
        public long IdEstado { get; set; }
        public long CodigoIbge { get; set; }
        public string Nome { get; set; }

        public TbEstado IdEstadoNavigation { get; set; }
        public ICollection<TbClienteEndereco> TbClienteEndereco { get; set; }
    }
}
