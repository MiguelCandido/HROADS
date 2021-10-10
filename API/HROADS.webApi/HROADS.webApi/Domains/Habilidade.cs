using System;
using System.Collections.Generic;

#nullable disable

namespace HROADS.webApi.Domains
{
    public partial class Habilidade
    {
        public Habilidade()
        {
            ClasseHabilidades = new HashSet<ClasseHabilidade>();
        }

        public byte IdHab { get; set; }
        public byte? IdTipoHab { get; set; }
        public string NomeHabilidade { get; set; }
        public string DescricaoHabilidade { get; set; }

        public virtual TipoHabilidade IdTipoHabNavigation { get; set; }
        public virtual ICollection<ClasseHabilidade> ClasseHabilidades { get; set; }
    }
}
