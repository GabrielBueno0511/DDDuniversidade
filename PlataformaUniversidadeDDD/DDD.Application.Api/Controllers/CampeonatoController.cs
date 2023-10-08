using DDD.Domain.Atletica;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampeonatoController : ControllerBase
    {

        readonly ICampeonatoRepository _campeonatoRepository;

        public CampeonatoController(ICampeonatoRepository campeonatoRepository)
        {
            _campeonatoRepository = campeonatoRepository;
        }

        // GET: api/<AlunosController>
        [HttpGet]
        public ActionResult<List<Campeonato>> Get()
        {
            return Ok(_campeonatoRepository.GetCampeonatos());
        }

        [HttpGet("{id}")]
        public ActionResult<Campeonato> GetById(int id)
        {
            return Ok(_campeonatoRepository.GetCampeonatoById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Campeonato> CreateCampeonato(Campeonato campeonato)
        {
            _campeonatoRepository.InsertCampeonato(campeonato);
            return CreatedAtAction(nameof(GetById), new { id = campeonato.CampeonatoId }, campeonato);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Campeonato campeonato)
        {
            try
            {
                if (campeonato == null)
                    return NotFound();

                _campeonatoRepository.UpdateCampeonato(campeonato);
                return Ok("Campeonato Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] Campeonato campeonato)
        {
            try
            {
                if (campeonato == null)
                    return NotFound();

                _campeonatoRepository.DeleteCampeonato(campeonato);
                return Ok("Campeonato Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
