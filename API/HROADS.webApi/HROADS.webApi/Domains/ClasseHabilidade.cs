using System;
using System.Collections.Generic;

#nullable disable

namespace HROADS.webApi.Domains
{
    public partial class ClasseHabilidade
    {
        public byte IdClasseHabilidade { get; set; }
        public byte? IdClasse { get; set; }
        public byte? IdHab { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
        public virtual Habilidade IdHabNavigation { get; set; }
    }
}
