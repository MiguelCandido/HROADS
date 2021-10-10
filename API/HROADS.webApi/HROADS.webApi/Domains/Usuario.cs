using System;
using System.Collections.Generic;

#nullable disable

namespace HROADS.webApi.Domains
{
    public partial class Usuario
    {
        public byte IdUsuario { get; set; }
        public byte? IdTipo { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoNavigation { get; set; }
    }
}
