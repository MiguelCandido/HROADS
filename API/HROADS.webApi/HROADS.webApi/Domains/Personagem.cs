using System;
using System.Collections.Generic;

#nullable disable

namespace HROADS.webApi.Domains
{
    public partial class Personagem
    {
        public byte IdPersonagem { get; set; }
        public byte? IdClasse { get; set; }
        public string NomePersonagem { get; set; }
        public short? VidaMax { get; set; }
        public short? ManaMax { get; set; }
        public DateTime? DataUpdate { get; set; }
        public DateTime? DataCriação { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
    }
}
