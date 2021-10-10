using HROADS.webApi.Interfaces;
using HROADS.webApi.Repositories;
using HROADS.webApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HROADS.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuariosRepository _usuarioRepository { get; set; }

        public LoginController(LoginViewModel login)
        {
            _usuarioRepository = new UsuarioRepository();
        }

    }
}
