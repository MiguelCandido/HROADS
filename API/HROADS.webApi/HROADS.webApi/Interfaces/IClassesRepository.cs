using HROADS.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HROADS.webApi.Interfaces
{
    interface IClassesRepository
    {
        void Cadastrar(Classe classe);

        void Editar(Classe classe, int id);

        void Excluir(int id);

        List<Classe> ListarTodas();

        Classe BuscarPorID(int id);
    }
}
