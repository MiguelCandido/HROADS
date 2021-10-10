using HROADS.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HROADS.webApi.Interfaces
{
    interface IClasseHabilidadeRepository
    {
        void Cadastrar(ClasseHabilidade intermedio);

        void Editar(ClasseHabilidade intermedio, int id);

        void Excluir(int id);

        List<ClasseHabilidade> ListarTodas();

        ClasseHabilidade BuscarPorID(int id);
    }
}
