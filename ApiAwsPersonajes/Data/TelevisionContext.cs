using ApiAwsPersonajes.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAwsPersonajes.Data
{
    public class TelevisionContext:DbContext
    {

        public TelevisionContext(DbContextOptions<TelevisionContext> options)    : base(options) { }


        public DbSet<Personaje> Personaje { get; set; }
    }
}
