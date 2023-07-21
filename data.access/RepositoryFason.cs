using data.access.Context;
using entity.entities;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.access
{
    public class RepositoryFason : IRepository
    {
        private IContext context;
        public RepositoryFason()
        {
            context = new Context_Concrete_fason();
        }

        public List<District> districts => context._Districts;
        public List<UserExt> users => context._Users;
        public List<WorkingPreference> workingPreferences => context._WorkingPreferences;

        public List<Motivation> motivations => context._Motivations;
    }
}
