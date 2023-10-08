using DDD.Domain.Atletica;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EsporteController: ControllerBase
    {
        readonly IEsporteRepository _esporteRepository;

        public EsporteController(IEsporteRepository esporteRepository)
        {
            _esporteRepository = esporteRepository;
        }

        // GET: api/<AlunosController>
        [HttpGet]
        public ActionResult<List<Esporte>> Get()
        {
            return Ok(_esporteRepository.GetEsportes());
        }

        [HttpGet("{id}")]
        public ActionResult<Esporte> GetById(int id)
        {
            return Ok(_esporteRepository.GetEsporteById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Esporte> CreateAtleta(Esporte esporte)
        {
            _esporteRepository.InsertEsporte(esporte);
            return CreatedAtAction(nameof(GetById), new { id = esporte.EsporteId }, esporte);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Esporte esporte)
        {
            try
            {
                if (esporte == null)
                    return NotFound();

                _esporteRepository.UpdateEsporte(esporte);
                return Ok("Esporte Atualizada com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] Esporte esporte)
        {
            try
            {
                if (esporte == null)
                    return NotFound();

                _esporteRepository.DeleteEsporte(esporte);
                return Ok("Esporte Removida com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}

