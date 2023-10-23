using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CrudKARYAWAN.Models;
using CrudKARYAWAN.Controllers;

namespace CrudKARYAWAN.Data
{

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CrudKARYAWAN.Models.KaryawanModel>? KaryawanModel { get; set; }


    }
}
