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
    public class PersonagensController : ControllerBase
    {
        private IPersonagensRepository _PersonagemRepository { get; set; }

        public PersonagensController()
        {
            _PersonagemRepository = new PersonagemRepository();

        }

        [HttpPost]
        public IActionResult Cadastrar(Personagem Personagem)
        {

            try
            {
                _PersonagemRepository.Cadastrar(Personagem);

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
            List<Personagem> listaPerso = _PersonagemRepository.ListarTodas();

            return Ok(listaPerso);
        }

        [HttpGet("{idPerso}")]
        public IActionResult BuscarPorID(int idPerso)
        {
            try
            {
                Personagem teste = _PersonagemRepository.BuscarPorID(idPerso);
                if (teste != null)
                {
                    return Ok(teste);
                }
                return NotFound("A Personagem não foi encontrada :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        [HttpPut("{idPerso}")]
        public IActionResult Atualizar(int idPerso, Personagem PersonagemUPDT)
        {
            try
            {
                Personagem teste = _PersonagemRepository.BuscarPorID(idPerso);
                if (teste != null)
                {
                    _PersonagemRepository.Editar(PersonagemUPDT, idPerso);

                    return StatusCode(204);
                }

                return NotFound("A Personagem não foi encontrada :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpDelete("{idPerso}")]
        public IActionResult Deletar(int idPerso)
        {
            try
            {
                Personagem teste = _PersonagemRepository.BuscarPorID(idPerso);
                if (teste != null)
                {
                    _PersonagemRepository.Excluir(idPerso);

                    return StatusCode(204);
                }

                return NotFound("A Personagem não foi encontrada :P");
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }
    }
}
