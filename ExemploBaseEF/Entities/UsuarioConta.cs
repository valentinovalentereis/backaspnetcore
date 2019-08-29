using System;
using System.Collections.Generic;

namespace ExemploBaseEF.Entities
{
    public partial class TbUsuarioConta : BaseEntity

    {
        public TbUsuarioConta()
        {

        }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Apelido { get; set; }
        public byte  TpDocumento  { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }

        public long IdUsuario { get; set; }
        public TbUsuario TbUsuario { get; set; }
        //public Usuario Usuarios { get; set; }
        //public ICollection<Usuario> Usuarios { get; set; }
    }
}
