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
    public class HabilidadesController : ControllerBase
    {
        private IHabilidadeRepository _HabilidadeRepository { get; set; }

        public HabilidadesController()
        {
            _HabilidadeRepository = new HabilidadeRepository();

        }

        [HttpPost]
        public IActionResult Cadastrar(Habilidade Habilidade)
        {

            try
            {
                _HabilidadeRepository.Cadastrar(Habilidade);

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
            List<Habilidade> listahab = _HabilidadeRepository.ListarTodas();

            return Ok(listahab);
        }

        [HttpGet("{idHab}")]
        public IActionResult BuscarPorID(int idHab)
        {
            try
            {
                Habilidade teste = _HabilidadeRepository.BuscarPorID(idHab);
                if (teste != null)
                {
                    return Ok(teste);
                }
                return NotFound("A Habilidade não foi encontrada :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        [HttpPut("{idHab}")]
        public IActionResult Atualizar(int idHab, Habilidade HabilidadeUPDT)
        {
            try
            {
                Habilidade teste = _HabilidadeRepository.BuscarPorID(idHab);
                if (teste != null)
                {
                    _HabilidadeRepository.Editar(HabilidadeUPDT, idHab);

                    return StatusCode(204);
                }

                return NotFound("A Habilidade não foi encontrada :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpDelete("{idHab}")]
        public IActionResult Deletar(int idHab)
        {
            try
            {
                Habilidade teste = _HabilidadeRepository.BuscarPorID(idHab);
                if (teste != null)
                {
                    _HabilidadeRepository.Excluir(idHab);

                    return StatusCode(204);
                }

                return NotFound("A Habilidade não foi encontrada :P");
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }
    }
}
