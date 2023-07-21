

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.entities
{
    public class UserExt  : IdentityUser<int>
    {

        public UserExt()
        {
            UserMotivation = new HashSet<UserMotivation>();

            UserWorkingPreference = new HashSet<UserWorkingPreference>();
        }

      
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Title { get; set; }

        public virtual ICollection<UserMotivation> UserMotivation { get; set; }

        public virtual ICollection<UserWorkingPreference> UserWorkingPreference { get; set; }
    }
}
