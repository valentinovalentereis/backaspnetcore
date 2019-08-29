using System;
using System.Collections.Generic;

namespace ExemploBaseEF.Entities
{
    public partial class TbPais: BaseEntity
    {
        public TbPais()
        {
            TbClienteEndereco = new HashSet<TbClienteEndereco>();
            TbEstado = new HashSet<TbEstado>();
        }

        //public long IdPais { get; set; }
        public long CodigoIbge { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }

        public ICollection<TbClienteEndereco> TbClienteEndereco { get; set; }
        public ICollection<TbEstado> TbEstado { get; set; }
    }
}
