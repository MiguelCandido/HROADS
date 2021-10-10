using HROADS.webApi.Contexts;
using HROADS.webApi.Domains;
using HROADS.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HROADS.webApi.Repositories
{
    public class PersonagemRepository : IPersonagensRepository
    {
        HROADSContext ctx = new HROADSContext();
        public Personagem BuscarPorID(int id)
        {
            return ctx.Personagems.FirstOrDefault(s => s.IdPersonagem == id);
        }

        public void Cadastrar(Personagem perso)
        {
            perso.DataCriação = DateTime.Now;
            perso.DataUpdate = DateTime.Now;

            ctx.Personagems.Add(perso);

            ctx.SaveChanges();
        }

        public void Editar(Personagem perso, int id)
        {
            Personagem persoBuscado = ctx.Personagems.FirstOrDefault(s => s.IdPersonagem == id);

            persoBuscado.DataUpdate = DateTime.Now;

            if (perso.NomePersonagem != null) { persoBuscado.NomePersonagem = perso.NomePersonagem; }
            if (perso.IdClasse != 0) { persoBuscado.IdClasse = perso.IdClasse; }
            if (perso.NomePersonagem != null) { persoBuscado.NomePersonagem = perso.NomePersonagem; }
            if (perso.VidaMax != null) { persoBuscado.VidaMax = perso.VidaMax; }
            if (perso.ManaMax != null) { persoBuscado.ManaMax = perso.ManaMax; }

            ctx.Personagems.Update(persoBuscado);

            ctx.SaveChanges();
        }

        public void Excluir(int id)
        {
            Personagem persoBuscado = ctx.Personagems.FirstOrDefault(s => s.IdPersonagem == id);

            ctx.Personagems.Remove(persoBuscado);

            ctx.SaveChanges();
        }

        public List<Personagem> ListarTodas()
        {
            return ctx.Personagems.ToList();
        }
    }
}
