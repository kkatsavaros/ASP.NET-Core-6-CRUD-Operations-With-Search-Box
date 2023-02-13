using GermanGrammar3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GermanGrammar3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<GermanModel> AllTogether { get; set; }  //AllTogether is the table name that we will create.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}