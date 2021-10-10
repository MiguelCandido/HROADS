using HROADS.webApi.Contexts;
using HROADS.webApi.Domains;
using HROADS.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HROADS.webApi.Repositories
{
    public class ClasseHabilidadeRepository : IClasseHabilidadeRepository
    {
        HROADSContext ctx = new HROADSContext();
        public ClasseHabilidade BuscarPorID(int id)
        {
            return ctx.ClasseHabilidades.FirstOrDefault(s => s.IdClasseHabilidade == id);
        }

        public void Cadastrar(ClasseHabilidade intermedio)
        {
            ctx.ClasseHabilidades.Add(intermedio);

            ctx.SaveChanges();
        }

        public void Editar(ClasseHabilidade intermedio, int id)
        {
            ClasseHabilidade classehabBuscada = ctx.ClasseHabilidades.FirstOrDefault(s => s.IdClasseHabilidade == id);

            if (intermedio.IdHab != 0) { classehabBuscada.IdHab = intermedio.IdHab; }
            if (intermedio.IdClasse != 0) { classehabBuscada.IdClasse = intermedio.IdClasse; }

            ctx.ClasseHabilidades.Update(classehabBuscada);

            ctx.SaveChanges();
        }

        public void Excluir(int id)
        {
            ClasseHabilidade classehabBuscada = ctx.ClasseHabilidades.FirstOrDefault(s => s.IdClasseHabilidade == id);

            ctx.ClasseHabilidades.Remove(classehabBuscada);

            ctx.SaveChanges();
        }

        public List<ClasseHabilidade> ListarTodas()
        {
            return ctx.ClasseHabilidades.ToList();
        }
    }
}
