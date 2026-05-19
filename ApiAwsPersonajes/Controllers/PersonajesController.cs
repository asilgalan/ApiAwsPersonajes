using ApiAwsPersonajes.Models;
using ApiAwsPersonajes.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAwsPersonajes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {

        private readonly PersonajesRepository personajesRepository;

        public PersonajesController(PersonajesRepository personajesRepository) {

            this.personajesRepository = personajesRepository;
                
         }


        [HttpGet]

        public async Task<ActionResult<List<Personaje>>> GetPersonajes()
        {

            List<Personaje> personajes = await this.personajesRepository.GetPersonajesAsync();
            return Ok(personajes);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Personaje>> GetPersonaje(int id)
        {
            Personaje personaje = await this.personajesRepository.GetPersonajeAsync(id);
            if (personaje == null)
            {
                return NotFound();
            }

            return Ok(personaje);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePersonaje([FromBody] Personaje personaje)
        {
            if (personaje == null)
            {
                return BadRequest();
            }

            await this.personajesRepository.CreatePersonaje(personaje);
            return CreatedAtAction(nameof(GetPersonaje), new { id = personaje.IdPersonaje }, personaje);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdatePersonaje(int id, [FromBody] Personaje personaje)
        {
            if (personaje == null || id != personaje.IdPersonaje)
            {
                return BadRequest();
            }

            Personaje existing = await this.personajesRepository.GetPersonajeAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

            await this.personajesRepository.UpdatePersonaje(personaje);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletePersonaje(int id)
        {
            Personaje existing = await this.personajesRepository.GetPersonajeAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

            await this.personajesRepository.DeletePersonajeAsync(id);
            return NoContent();
        }
    }
}
