using Microsoft.EntityFrameworkCore;
using Studentportal.Model.Entities;

namespace Studentportal.Data
{
    public class ApplicationDbcontext :DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options) 
        { 
        
            
        }
        public DbSet<Student> Students { get; set; }
    }
}

