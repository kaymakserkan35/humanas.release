using entity.entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace data.access.Context
{
    public class ContextConcete : IdentityDbContext<UserExt, IdentityRole<int>, int>, IContext
    {

        public DbSet<Motivation> Motivations { get; set; }
        public DbSet<District> Districts { get; set; }

        public ContextConcete(DbContextOptions<ContextConcete> options) : base(options)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
        }

        
        public DbSet<WorkingPreference> WorkingPreferences { get; set; }
        public List<UserExt> _Users { get => this.Users.ToList(); set => throw new NotImplementedException(); }
        public List<District> _Districts { get => this.Districts.ToList(); set => throw new NotImplementedException(); }
        public List<Motivation> _Motivations { get => Motivations.ToList(); set => throw new NotImplementedException(); }
        public List<WorkingPreference> _WorkingPreferences { get => WorkingPreferences.ToList(); set => throw new NotImplementedException(); }

       
    }
}
