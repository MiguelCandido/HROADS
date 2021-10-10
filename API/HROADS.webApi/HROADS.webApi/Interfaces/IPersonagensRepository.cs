using HROADS.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HROADS.webApi.Interfaces
{
    interface IPersonagensRepository
    {
        void Cadastrar(Personagem perso);

        void Editar(Personagem perso, int id);

        void Excluir(int id);

        List<Personagem> ListarTodas();

        Personagem BuscarPorID(int id);
    }
}
