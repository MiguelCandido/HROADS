using HROADS.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HROADS.webApi.Interfaces
{
    interface IHabilidadeRepository
    {
        void Cadastrar(Habilidade hab);

        void Editar(Habilidade hab, int id);

        void Excluir(int id);

        List<Habilidade> ListarTodas();

        Habilidade BuscarPorID(int id);
    }
}
