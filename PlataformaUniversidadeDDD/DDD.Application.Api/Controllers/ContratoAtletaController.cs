using DDD.Domain.Atletica;
using DDD.Domain.SecretariaContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoAtletaController : ControllerBase
    {
        readonly IContratoAtletaRepository _contratoAtletaRepository;

        public ContratoAtletaController(IContratoAtletaRepository contratoAtletaRepository)
        {
            _contratoAtletaRepository = contratoAtletaRepository;
        }

        // GET: api/<AlunosController>
        [HttpGet]
        public ActionResult<List<ContratoAtleta>> Get()
        {
            return Ok(_contratoAtletaRepository.GetContratoAtleta());
        }

        [HttpGet("{id}")]
        public ActionResult<ContratoAtleta> GetById(int id)
        {
            return Ok(_contratoAtletaRepository.GetContratoAtletaById(id));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ContratoAtleta> CreateMatricula(int idAtleta, int idEsporte)
        {
            ContratoAtleta contratoAtletaIdSaved = _contratoAtletaRepository.InsertContratoAtleta(idAtleta, idEsporte);
            return CreatedAtAction(nameof(GetById), new { id = contratoAtletaIdSaved.ContratoId }, contratoAtletaIdSaved);
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] ContratoAtleta ContratoAtleta)
        {
            try
            {
                if (ContratoAtleta == null)
                    return NotFound();

                _contratoAtletaRepository.DeleteContratoAtleta(ContratoAtleta);
                return Ok("ContratoAtleta Removida com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
