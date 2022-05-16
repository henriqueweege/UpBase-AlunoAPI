using AlunoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AlunoAPI.Data
{
    public class AlunoContext : DbContext
    {
        public AlunoContext(DbContextOptions<AlunoContext> opt) : base(opt) 
        { 
        }
    
        public DbSet<Aluno> Aluno { get; set; }
    
    }
}
