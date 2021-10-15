using HROADS.webApi.Contexts;
using HROADS.webApi.Domains;
using HROADS.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HROADS.webApi.Repositories
{
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {
        HROADSContext ctx = new HROADSContext();
        public TipoHabilidade BuscarPorID(int id)
        {
            return ctx.TipoHabilidades.FirstOrDefault(s => s.IdTipoHab == id);
        }

        public void Cadastrar(TipoHabilidade tipoHab)
        {
            ctx.TipoHabilidades.Add(tipoHab);

            ctx.SaveChanges();
        }

        public void Editar(TipoHabilidade tipoHab, int id)
        {
            TipoHabilidade tipohabBuscada = ctx.TipoHabilidades.FirstOrDefault(s => s.IdTipoHab == id);

            if (tipoHab.NomeTipo != null) { tipohabBuscada.NomeTipo = tipoHab.NomeTipo; }

            ctx.TipoHabilidades.Update(tipohabBuscada);

            ctx.SaveChanges();
        }

        public void Excluir(int id)
        {
            TipoHabilidade tipohabBuscada = ctx.TipoHabilidades.FirstOrDefault(s => s.IdTipoHab == id);

            ctx.TipoHabilidades.Remove(tipohabBuscada);

            ctx.SaveChanges();
        }

        public List<TipoHabilidade> ListarTodas()
        {
            return ctx.TipoHabilidades.ToList();
        }
    }
}
