using data.access.Context;
using entity.entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.access
{
    public class RepositoryConcrete : IRepository
    {
        readonly ContextConcete context;

        public RepositoryConcrete(ContextConcete context)
        {
            this.context = context;
        }

        public List<District> districts => context.Districts.ToList();

        public List<Motivation> motivations => context.Motivations.ToList();

        public List<WorkingPreference> workingPreferences => context.WorkingPreferences.ToList();

        public List<UserExt> persons => context.Users.ToList();
    }
}
