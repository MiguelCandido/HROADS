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
    public class TipoHabilidadeController : ControllerBase
    {
        private ITipoHabilidadeRepository _TipoHabilidadeRepository { get; set; }

        public TipoHabilidadeController()
        {
            _TipoHabilidadeRepository = new TipoHabilidadeRepository();

        }

        [HttpPost]
        public IActionResult Cadastrar(TipoHabilidade TipoHabilidade)
        {

            try
            {
                _TipoHabilidadeRepository.Cadastrar(TipoHabilidade);

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
            List<TipoHabilidade> listaTipos = _TipoHabilidadeRepository.ListarTodas();

            return Ok(listaTipos);
        }

        [HttpGet("{idtipo}")]
        public IActionResult BuscarPorID(int idtipo)
        {
            try
            {
                TipoHabilidade teste = _TipoHabilidadeRepository.BuscarPorID(idtipo);
                if (teste != null)
                {
                    return Ok(teste);
                }
                return NotFound("O Tipo de Habilidade não foi encontrado :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        [HttpPut("{idtipo}")]
        public IActionResult Atualizar(int idtipo, TipoHabilidade TipoHabilidadeUPDT)
        {
            try
            {
                TipoHabilidade teste = _TipoHabilidadeRepository.BuscarPorID(idtipo);
                if (teste != null)
                {
                    _TipoHabilidadeRepository.Editar(TipoHabilidadeUPDT, idtipo);

                    return StatusCode(204);
                }

                return NotFound("O Tipo de Habilidade não foi encontrado :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpDelete("{idtipo}")]
        public IActionResult Deletar(int idtipo)
        {
            try
            {
                TipoHabilidade teste = _TipoHabilidadeRepository.BuscarPorID(idtipo);
                if (teste != null)
                {
                    _TipoHabilidadeRepository.Excluir(idtipo);

                    return StatusCode(204);
                }

                return NotFound("O Tipo de Habilidade não foi encontrado :P");
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }
    }
}
