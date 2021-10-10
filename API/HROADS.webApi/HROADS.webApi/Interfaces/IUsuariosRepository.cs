using HROADS.webApi.Domains;
using HROADS.webApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HROADS.webApi.Interfaces
{
    interface IUsuariosRepository
    {
        void Cadastrar(Usuario user);

        void Editar(Usuario user, int id);

        void Excluir(int id);

        List<Usuario> ListarTodas();

        Usuario BuscarPorID(int id);
        Usuario login(LoginViewModel cred);
    }
}
