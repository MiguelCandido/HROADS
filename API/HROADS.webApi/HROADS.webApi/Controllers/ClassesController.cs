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
    public class ClassesController : ControllerBase
    {
        private IClassesRepository _classeRepository { get; set; }

        public ClassesController()
        {
            _classeRepository = new ClasseRepository();

        }

        [HttpPost]
        public IActionResult Cadastrar(Classe classe)
        {

            try
            {
                _classeRepository.Cadastrar(classe);

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
            List<Classe> liscaClass = _classeRepository.ListarTodas();

            return Ok(liscaClass);
        }

        [HttpGet("{idClass}")]
        public IActionResult BuscarPorID(int idClass)
        {
            try
            {
                Classe teste = _classeRepository.BuscarPorID(idClass);
                if (teste != null)
                {
                    return Ok(teste);
                }
                return NotFound("A classe não foi encontrada :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        [HttpPut("{idClass}")]
        public IActionResult Atualizar(Classe classeUPDT, int idClass)
        {
            try
            {
                Classe teste = _classeRepository.BuscarPorID(idClass);
                if (teste != null)
                {
                    _classeRepository.Editar(classeUPDT, idClass);

                    return StatusCode(204);
                }

                return NotFound("A classe não foi encontrada :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpDelete("{idClass}")]
        public IActionResult Deletar(int idClass)
        {
            try
            {
                Classe teste = _classeRepository.BuscarPorID(idClass);
                if (teste != null)
                {
                    _classeRepository.Excluir(idClass);

                    return StatusCode(204);
                }

                return NotFound("A classe não foi encontrada :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }
    }
}
