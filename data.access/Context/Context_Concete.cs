using entity.entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.access.Context
{
    public class Context_Concete : IdentityDbContext<UserExt, IdentityRole<int>, int>, IContext
    {
        public Context_Concete(DbContextOptions<Context_Concete> options) : base(options) { }

        public DbSet<District> Districts { get; set; }
        public DbSet<Motivation> Motivations { get; set; }
        public DbSet<WorkingPreference> WorkingPreferences { get; set; }

        public List<UserExt> _Users => throw new NotImplementedException();

        public List<District> _Districts => throw new NotImplementedException();

        public List<Motivation> _Motivations => throw new NotImplementedException();

        public List<WorkingPreference> _WorkingPreferences => throw new NotImplementedException();
    }
}
