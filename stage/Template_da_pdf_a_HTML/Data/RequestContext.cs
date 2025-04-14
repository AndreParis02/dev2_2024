using Microsoft.EntityFrameworkCore;

namespace Template_da_pdf_a_HTML.Data
{
    public class RequestContext : DbContext
    {
        public RequestContext (DbContextOptions<RequestContext> options)
            : base(options)
        {
        }

        public DbSet<Richiesta> Richieste { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Richiesta>().ToTable("Richiesta");
        }
        public DbSet<Utente> Utente { get; set; }
        public DbSet<Prestito> Prestito { get; set; }
        public DbSet<DocumentoUtente> DocumentoUtente { get; set; }
        public DbSet<Libro> Libro { get; set; }
        public DbSet<Tipo> Tipo { get; set; }
        public DbSet<Genere> Genere { get; set; }
        public DbSet<Autore> Autore { get; set; }
    }
}