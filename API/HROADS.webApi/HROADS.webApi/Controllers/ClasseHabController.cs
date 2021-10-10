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
    public class ClasseHabController : ControllerBase
    {
        private IClasseHabilidadeRepository _ClasseHabilidadeRepository { get; set; }

        public ClasseHabController()
        {
            _ClasseHabilidadeRepository = new ClasseHabilidadeRepository();

        }

        [HttpPost]
        public IActionResult Cadastrar(ClasseHabilidade ClasseHabilidade)
        {

            try
            {
                _ClasseHabilidadeRepository.Cadastrar(ClasseHabilidade);

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
            List<ClasseHabilidade> listaTipos = _ClasseHabilidadeRepository.ListarTodas();

            return Ok(listaTipos);
        }

        [HttpGet("{idClassHab}")]
        public IActionResult BuscarPorID(int idClassHab)
        {
            try
            {
                ClasseHabilidade teste = _ClasseHabilidadeRepository.BuscarPorID(idClassHab);
                if (teste != null)
                {
                    return Ok(teste);
                }
                return NotFound("A relação Classe-Habilidade não foi encontrada :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        [HttpPut("{idClassHab}")]
        public IActionResult Atualizar(int idClassHab, ClasseHabilidade ClasseHabilidadeUPDT)
        {
            try
            {
                ClasseHabilidade teste = _ClasseHabilidadeRepository.BuscarPorID(idClassHab);
                if (teste != null)
                {
                    _ClasseHabilidadeRepository.Editar(ClasseHabilidadeUPDT, idClassHab);

                    return StatusCode(204);
                }

                return NotFound("A relação Classe-Habilidade não foi encontrada :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpDelete("{idClassHab}")]
        public IActionResult Deletar(int idClassHab)
        {
            try
            {
                ClasseHabilidade teste = _ClasseHabilidadeRepository.BuscarPorID(idClassHab);
                if (teste != null)
                {
                    _ClasseHabilidadeRepository.Excluir(idClassHab);

                    return StatusCode(204);
                }

                return NotFound("A relação Classe-Habilidade não foi encontrada :P");
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }
    }
}
