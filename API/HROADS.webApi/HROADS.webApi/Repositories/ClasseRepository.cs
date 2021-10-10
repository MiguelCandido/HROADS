using HROADS.webApi.Contexts;
using HROADS.webApi.Domains;
using HROADS.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HROADS.webApi.Repositories
{
    public class ClasseRepository : IClassesRepository
    {
        HROADSContext ctx = new HROADSContext();
        public Classe BuscarPorID(int id)
        {
            return ctx.Classes.FirstOrDefault(s => s.IdClasse == id);
        }

        public void Cadastrar(Classe classe)
        {
            ctx.Classes.Add(classe);

            ctx.SaveChanges();
        }

        public void Editar(Classe classe, int id)
        {
            Classe classeBuscada = ctx.Classes.FirstOrDefault(s => s.IdClasse == id);

            if (classe.NomeClasse != null) { classeBuscada.NomeClasse = classe.NomeClasse; }

            ctx.Classes.Update(classeBuscada);

            ctx.SaveChanges();
        }

        public void Excluir(int id)
        {
            Classe classeBuscada = ctx.Classes.FirstOrDefault(s => s.IdClasse == id);

            ctx.Classes.Remove(classeBuscada);

            ctx.SaveChanges();
        }

        public List<Classe> ListarTodas()
        {
            return ctx.Classes.ToList();
        }
    }
}
