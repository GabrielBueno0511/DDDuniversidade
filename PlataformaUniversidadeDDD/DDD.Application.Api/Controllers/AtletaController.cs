using DDD.Domain.Atletica;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtletaController : ControllerBase
    {
        readonly IAtletaRepository _atletaRepository;

        public AtletaController(IAtletaRepository atletaRepository)
        {
            _atletaRepository = atletaRepository;
        }

        // GET: api/<AtletasController>
        [HttpGet]
        public ActionResult<List<Atleta>> Get()
        {
            return Ok(_atletaRepository.GetAtletas());
        }

        [HttpGet("{id}")]
        public ActionResult<Atleta> GetById(int id)
        {
            return Ok(_atletaRepository.GetAtletaById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Atleta> CreateAtleta(Atleta Atleta)
        {
            if (Atleta.Nome.Length < 3 || Atleta.Nome.Length > 30)
            {
                return BadRequest("Nome deve ser maior que 3 e menor que 30 caracteres.");
            }
            _atletaRepository.InsertAtleta(Atleta);
            return CreatedAtAction(nameof(GetById), new { id = Atleta.UserId }, Atleta);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Atleta atleta)
        {
            try
            {
                if (atleta == null)
                    return NotFound();

                _atletaRepository.UpdateAtleta(atleta);
                return Ok("Atleta Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] Atleta atleta)
        {
            try
            {
                if (atleta == null)
                    return NotFound();

                _atletaRepository.DeleteAtleta(atleta);
                return Ok("Atleta Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
