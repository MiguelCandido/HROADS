using HROADS.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HROADS.webApi.Interfaces
{
    interface ITipoHabilidadeRepository
    {
        void Cadastrar(TipoHabilidade tipoHab);

        void Editar(TipoHabilidade tipoHab, int id);

        void Excluir(int id);

        List<TipoHabilidade> ListarTodas();

        TipoHabilidade BuscarPorID(int id);
    }
}
