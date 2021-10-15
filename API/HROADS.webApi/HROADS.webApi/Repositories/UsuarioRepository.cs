using HROADS.webApi.Contexts;
using HROADS.webApi.Domains;
using HROADS.webApi.Interfaces;
using HROADS.webApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HROADS.webApi.Repositories
{
    public class UsuarioRepository : IUsuariosRepository
    {
        HROADSContext ctx = new HROADSContext();
        public Usuario BuscarPorID(int id)
        {
            return ctx.Usuarios.FirstOrDefault(s => s.IdUsuario == id);
        }

        public void Cadastrar(Usuario user)
        {
            ctx.Usuarios.Add(user);

            ctx.SaveChanges();
        }

        public void Editar(Usuario user, int id)
        {
            Usuario userBuscado = ctx.Usuarios.FirstOrDefault(s => s.IdUsuario == id);

            if (user.Email != null) { userBuscado.Email = user.Email; }
            if (user.Senha != null) { userBuscado.Senha = user.Senha; }
            if (user.IdTipo != 0) { userBuscado.IdTipo = user.IdTipo; }

            ctx.Usuarios.Update(userBuscado);

            ctx.SaveChanges();
        }

        public void Excluir(int id)
        {
            Usuario userBuscado = ctx.Usuarios.FirstOrDefault(s => s.IdUsuario == id);

            ctx.Usuarios.Remove(userBuscado);

            ctx.SaveChanges();
        }

        public List<Usuario> ListarTodas()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario login(LoginViewModel cred)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == cred.Email && u.Senha == cred.Senha);
        }
    }
}
