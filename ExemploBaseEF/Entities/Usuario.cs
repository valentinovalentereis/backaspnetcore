using System;
using System.Collections.Generic;

namespace ExemploBaseEF.Entities
{
    public partial class TbUsuario : BaseEntity

    {
        public TbUsuario()
        {
            //UsuarioConta = new HashSet<UsuarioConta>();
        }

        public string Login { get; set; }
        public string Senha { get; set; }

        public TbUsuarioConta TbUsuarioConta { get; set; }
        //public ICollection<UsuarioConta> UsuarioConta { get; set; }
        //public ICollection<Pedido> Pedidos { get; set; }
    }
}
