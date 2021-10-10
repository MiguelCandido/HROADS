using HROADS.webApi.Contexts;
using HROADS.webApi.Domains;
using HROADS.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HROADS.webApi.Repositories
{
    public class HabilidadeRepository : IHabilidadeRepository
    {
        HROADSContext ctx = new HROADSContext();
        public Habilidade BuscarPorID(int id)
        {
            return ctx.Habilidades.FirstOrDefault(s => s.IdHab == id);
        }

        public void Cadastrar(Habilidade hab)
        {
            ctx.Habilidades.Add(hab);

            ctx.SaveChanges();
        }

        public void Editar(Habilidade hab, int id)
        {
            Habilidade habilidadeBuscada = ctx.Habilidades.FirstOrDefault(s => s.IdHab == id);

            if (hab.NomeHabilidade != null) { habilidadeBuscada.NomeHabilidade = hab.NomeHabilidade; }
            if (hab.DescricaoHabilidade != null) { habilidadeBuscada.DescricaoHabilidade = hab.DescricaoHabilidade; }
            if (hab.IdTipoHab != 0) { habilidadeBuscada.IdTipoHab = hab.IdTipoHab; }

            ctx.Habilidades.Update(habilidadeBuscada);

            ctx.SaveChanges();
        }

        public void Excluir(int id)
        {
            Habilidade habilidadeBuscada = ctx.Habilidades.FirstOrDefault(s => s.IdHab == id);

            ctx.Habilidades.Remove(habilidadeBuscada);

            ctx.SaveChanges();
        }

        public List<Habilidade> ListarTodas()
        {
            return ctx.Habilidades.ToList();
        }
    }
}
