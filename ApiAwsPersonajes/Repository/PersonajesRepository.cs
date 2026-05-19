using ApiAwsPersonajes.Data;
using ApiAwsPersonajes.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ApiAwsPersonajes.Repository
{
    public class PersonajesRepository
    {

        private readonly TelevisionContext context;

        public PersonajesRepository(TelevisionContext context)
        {
            this.context = context;
        }


        public async Task<List<Personaje>> GetPersonajesAsync()
        {

            return await this.context.Personaje.ToListAsync();
        }

        public async Task<Personaje> GetPersonajeAsync(int id)
        {

            return await this.context.Personaje.FirstOrDefaultAsync(a => a.IdPersonaje==id);
        }

        public async Task CreatePersonaje(Personaje personaje)
        {


            await this.context.AddAsync(personaje);
            await this.context.SaveChangesAsync();


        }

        public async Task UpdatePersonaje(Personaje personaje)
        {


             this.context.Update(personaje);
             await this.context.SaveChangesAsync();


        }

        public async Task DeletePersonajeAsync(int id)
        {

            Personaje personaje = await this.GetPersonajeAsync(id);

            this.context.Personaje.Remove(personaje);
            this.context.SaveChangesAsync();
        }
    }
}
