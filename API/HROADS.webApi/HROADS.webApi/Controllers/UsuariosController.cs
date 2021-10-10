using HROADS.webApi.Domains;
using HROADS.webApi.Interfaces;
using HROADS.webApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HROADS.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuariosRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();

        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario user)
        {

            try
            {
                _usuarioRepository.Cadastrar(user);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        [HttpGet]
        public IActionResult Listar()
        {
            List<Usuario> listaUser = _usuarioRepository.ListarTodas();

            return Ok(listaUser);
        }

        [HttpGet("{idUser}")]
        public IActionResult BuscarPorID(int idUser)
        {
            try
            {
                Usuario teste = _usuarioRepository.BuscarPorID(idUser);
                if (teste != null)
                {
                    return Ok(teste);
                }
                return NotFound("O usuario não foi encontrado :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        [HttpPut("{idUser}")]
        public IActionResult Atualizar(int idUser, Usuario usuarioUPDT)
        {
            try
            {
                Usuario teste = _usuarioRepository.BuscarPorID(idUser);
                if (teste != null)
                {
                    _usuarioRepository.Editar(usuarioUPDT, idUser);

                    return StatusCode(204);
                }

                return NotFound("O usuario não foi encontrado :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpDelete("{idUser}")]
        public IActionResult Deletar(int idUser)
        {
            try
            {
                Usuario teste = _usuarioRepository.BuscarPorID(idUser);
                if (teste != null)
                {
                    _usuarioRepository.Excluir(idUser);

                    return StatusCode(204);
                }

                return NotFound("O usuario não foi encontrado :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

    }
}
