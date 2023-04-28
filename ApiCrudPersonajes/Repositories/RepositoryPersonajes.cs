using ApiCrudPersonajes.Data;
using ApiCrudPersonajes.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudPersonajes.Repositories
{
    public class RepositoryPersonajes
    {
        private PersonajesContext context;
        public RepositoryPersonajes(PersonajesContext context)
        {
            this.context = context;
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task<Personaje> FindPersonajeAsync(int id)
        {
            return await this.context.Personajes.FirstOrDefaultAsync(x => x.IdPersonaje == id);
        }

        public async Task InsertPersonajeAsync(int idpersonaje, string nombre, string imagen, int idserie)
        {
            Personaje personaje = new Personaje
            {
                IdPersonaje = idpersonaje,
                Nombre = nombre,
                Imagen = imagen,
                IdSerie = idserie
            };

            await this.context.Personajes.AddAsync(personaje);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdatePersonajeAsync(int idpersonaje, string nombre, string imagen, int idserie)
        {
            Personaje personaje = new Personaje
            {
                IdPersonaje = idpersonaje,
                Nombre = nombre,
                Imagen = imagen,
                IdSerie = idserie
            };

            this.context.Personajes.Update(personaje);
            await this.context.SaveChangesAsync();
        }

        public async Task DeletePersonajeAsync(int id)
        {
            Personaje personaje = await this.FindPersonajeAsync(id);
            this.context.Personajes.Remove(personaje);
            await this.context.SaveChangesAsync();
        }
    }
}
